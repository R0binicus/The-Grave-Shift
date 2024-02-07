using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource MusicSource;

    public AudioSource[] AudioSourceArray;

    public SoundAudioClip[] SoundAudioClipArray;

    public SoundAudioClip[] MusicAudioClipArray;

    [SerializeField] AudioMixer _mixer; 

    private List<SoundType> CurrentSoundsList = new List<SoundType>();

    private bool _musicMuted = false;

    private float _sfxVolume = 1;
    private float _musicVolume = 1;

    private void Awake()
    {
        EventManager.EventInitialise(EventType.SFX);
        EventManager.EventInitialise(EventType.MUTEMUSIC_TOGGLE);
    }

    private void OnEnable()
    {
        EventManager.EventSubscribe(EventType.SFX, SFXEventHandler);
        EventManager.EventSubscribe(EventType.MUSIC, MusicEventHandler);
        EventManager.EventSubscribe(EventType.STOP_MUSIC, StopMusic);
        EventManager.EventSubscribe(EventType.PAUSE_MUSIC, PauseMusic);
        EventManager.EventSubscribe(EventType.MUTEMUSIC_TOGGLE, MuteMusic);
        EventManager.EventSubscribe(EventType.SFXVOLUME, SFXVolumeHandler);
        EventManager.EventSubscribe(EventType.MUSICVOLUME, MusicVolumeHandler);
        EventManager.EventSubscribe(EventType.REQUESTSETTING, SettingsRequestHandler);
    }

    private void OnDisable()
    {
        EventManager.EventUnsubscribe(EventType.SFX, SFXEventHandler);
        EventManager.EventUnsubscribe(EventType.MUSIC, MusicEventHandler);
        EventManager.EventUnsubscribe(EventType.STOP_MUSIC, StopMusic);
        EventManager.EventUnsubscribe(EventType.PAUSE_MUSIC, PauseMusic);
        EventManager.EventUnsubscribe(EventType.MUTEMUSIC_TOGGLE, MuteMusic);
        EventManager.EventUnsubscribe(EventType.SFXVOLUME, SFXVolumeHandler);
        EventManager.EventUnsubscribe(EventType.MUSICVOLUME, MusicVolumeHandler);
        EventManager.EventUnsubscribe(EventType.REQUESTSETTING, SettingsRequestHandler);
        StopAllCoroutines();
    }

    // Handles SFXEvent with incoming SFX data to play at specified cue source
    public void SFXEventHandler(object data)
    {
        if (data == null) return;

        SoundType sound = (SoundType)data;

        //Find SoundAudioClip from array that has the same sound variable as the input
        SoundAudioClip clipSound = Array.Find(SoundAudioClipArray, x => x.sound == sound);

        if (clipSound == null)
        {
            Debug.LogError("SoundAudioClip's sound not found " + sound);
        }
        else
        {
            //Find first AudioSource that is not playing
            AudioSource source = Array.Find(AudioSourceArray, x => x.isPlaying == false);
            if (source == null)
            {
                Debug.Log("No audio source available to play this sound!");
            }
            else
            {
                if (!CurrentSoundsList.Contains(sound))
                {
                    if (clipSound.randomisePitch)
                    {
                        source.pitch = 1f;
                        source.pitch = UnityEngine.Random.Range(0.7f, 1.3f);
                    }
                    source.PlayOneShot(clipSound.audioClip, clipSound.volume * _sfxVolume);
                    StartCoroutine(DoNotPlayMultipleOfSame(sound));
                }
            }
        }
    }

    public void MusicEventHandler(object data)
    {        
        if (!_musicMuted)
        {
            if (data == null) return;

            StopMusic(null);

            SoundType music = (SoundType)data;

            SoundAudioClip musicClip = Array.Find(MusicAudioClipArray, x => x.sound == music);

            if (musicClip == null)
            {
                Debug.LogError("SoundAudioClip's music track not found " + music);
            }
            else
            {
                MusicSource.clip = musicClip.audioClip;
                MusicSource.volume = musicClip.volume;
                MusicSource.Play();
            }
        }
    }

    public void PauseMusic(object data)
    {
        if (!_musicMuted)
        {
            if (data == null)
            {
                Debug.LogError("Pause music has not received a bool");
            }

            bool paused = (bool)data;

            if (paused)
            {
                MusicSource.Pause();
            }
            else
            {
                MusicSource.Play();
            }
        }
    }

    public void StopMusic(object data)
    {
        MusicSource.Stop();
    }

    public void MuteMusic(object data)
    {
        _musicMuted = !_musicMuted;
        if (_musicMuted)
        {
            StopMusic(null);
        }
        else
        {
            MusicSource.Play();
        }
    }

    private IEnumerator DoNotPlayMultipleOfSame(SoundType sound)
    {
        CurrentSoundsList.Add(sound);
        yield return new WaitForSeconds(0.1f);
        CurrentSoundsList.Remove(sound);
    }

    public void SFXVolumeHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("SFXVolumeHandler is null!");
        }

        _sfxVolume = (float)data;
    }

    public void MusicVolumeHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("MusicVolumeHandler is null!");
        }

        _musicVolume = (float)data;
        _mixer.SetFloat("MusicVolume", Mathf.Log10(_musicVolume)*20);
    }

    public void SettingsRequestHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("SettingsRequestHandler is null!");
        }

        string setting = (string)data;

        if (setting == "SOUND")
        {
            SettingsData tempSettings = new SettingsData(_sfxVolume,_musicVolume,0f,0);
            EventManager.EventTrigger(EventType.SENDSETTING, tempSettings);
        }
    }
}

[Serializable]
public class SoundAudioClip
{
    public SoundType sound;
    public AudioClip audioClip;
    public bool randomisePitch = false;
    [Range(0, 1)] public float volume = 1f;
}