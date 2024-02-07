using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class MainMenuUIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] GameObject _settingsPanel; 
    [SerializeField] Toggle _fullscreenToggle; 
    [SerializeField] Toggle _largeResolutionToggle; 
    [SerializeField] Toggle _medResolutionToggle; 
    [SerializeField] Toggle _smallResolutionToggle; 
    [SerializeField] Slider _sfxSlider; 
    [SerializeField] Slider _musicSlider; 
    [SerializeField] Slider _textSpeedSlider; 
    [SerializeField] TextMeshProUGUI _textSpeedDisplay; 


    [Header("Sound")]
    [SerializeField] SoundType _titleMusic; 
    [SerializeField] SoundType _buttonSFX01;
    [SerializeField] SoundType _buttonSFX02;
    [SerializeField] SoundType _buttonSFX03;

    
    private string _receiver;
    private bool _buttonPressed = false; // Stops multiple clicking of same button

    private int _resolutionWidth;

    #region Init

    private void Awake()
    {
        EventManager.EventInitialise(EventType.MAINMENUEVENT);
        EventManager.EventInitialise(EventType.SFXVOLUME);
        EventManager.EventInitialise(EventType.MUSICVOLUME);
        EventManager.EventInitialise(EventType.TEXTSPEED);
        EventManager.EventInitialise(EventType.WINDOWRESOLUTION);
    }

    private void OnEnable()
    {
        EventManager.EventSubscribe(EventType.MAINMENUEVENT, MainMenuEventHandler);
        EventManager.EventSubscribe(EventType.SENDSETTING, SettingsSendHandler);
    }

    private void OnDisable()
    {
        EventManager.EventUnsubscribe(EventType.MAINMENUEVENT, MainMenuEventHandler);
        EventManager.EventUnsubscribe(EventType.SENDSETTING, SettingsSendHandler);
    }

    private void Start()
    {
        _buttonPressed = false;
        EventManager.EventTrigger(EventType.MUSIC, _titleMusic);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        _receiver = "SOUND";
        EventManager.EventTrigger(EventType.REQUESTSETTING, _receiver);
        _receiver = "MENU";
        EventManager.EventTrigger(EventType.REQUESTSETTING, _receiver);

        switch (_resolutionWidth)
        {
            case 2048:
                if (Screen.fullScreen == true)
                {
                    _fullscreenToggle.SetIsOnWithoutNotify(true);
                }
                else
                {
                    _largeResolutionToggle.SetIsOnWithoutNotify(true);
                }
            break;
            case 1440:
                _medResolutionToggle.SetIsOnWithoutNotify(true);
            break;
            case 1024:
                _smallResolutionToggle.SetIsOnWithoutNotify(true);
            break;
        }
    }
    #endregion
    // Button to signal exiting the game
    public void QuitButton()
    {
        EventManager.EventTrigger(EventType.QUIT_GAME, null);
    }

    public void LevelSelectButton(int levelNum)
    {
        if (!_buttonPressed)
        {
            EventManager.EventTrigger(EventType.LEVEL_SELECTED, levelNum);
            _buttonPressed = true;
        }
    }

    public void ButtonSFX01()
    {
        EventManager.EventTrigger(EventType.SFX, _buttonSFX01);
    }
    public void ButtonSFX02()
    {
        EventManager.EventTrigger(EventType.SFX, _buttonSFX02);
    }
    public void ButtonSFX03()
    {
        EventManager.EventTrigger(EventType.SFX, _buttonSFX03);
    }

    public void SettingsSendHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("SettingsSendHandler is null!");
        }

        SettingsData tempSettings = (SettingsData)data;

        if (tempSettings.SFX != 0f)
        {
            _sfxSlider.value = tempSettings.SFX;
        }
        if (tempSettings.Music != 0f)
        {
            _musicSlider.value = tempSettings.Music;
        }
        if (tempSettings.CharactersPerSec != 0f)
        {
            _textSpeedSlider.value = tempSettings.CharactersPerSec;
        }
        if (tempSettings.ResolutionWidth != 0)
        {
            _resolutionWidth = tempSettings.ResolutionWidth;
        }
    }

    public void MainMenuEventHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("MainMenuEventHandler hasn't received a string");
        }

        int code = (int)data;

        switch (code)
        {
            case 1:
                // Quit
                if (!_buttonPressed)
                {
                    EventManager.EventTrigger(EventType.SFX, _buttonSFX01);
                    EventManager.EventTrigger(EventType.QUIT_GAME, null);
                    _buttonPressed = true;
                }
                break;
            case 2:
                // Play
                if (!_buttonPressed)
                {
                    EventManager.EventTrigger(EventType.SFX, _buttonSFX03);
                    EventManager.EventTrigger(EventType.LEVEL_SELECTED, 0);
                    _buttonPressed = true;
                }
                break;
            case 3:
                // Options
                if (!_buttonPressed)
                {
                    EventManager.EventTrigger(EventType.SFX, _buttonSFX02);
                    ShowHideSettings();
                }
                break;
            default:
                
                break;
        }
    }

    public void ShowHideSettings()
    {
        _buttonPressed = !_buttonPressed;
        if (_settingsPanel.activeInHierarchy)
        {
            _settingsPanel.SetActive(false);
        }
        else
        {
            _settingsPanel.SetActive(true);
        }
    }
    public void SFXChanger(float updatedRange)
    {
        EventManager.EventTrigger(EventType.SFXVOLUME, updatedRange);
    }

    public void MusicChanger(float updatedRange)
    {
        EventManager.EventTrigger(EventType.MUSICVOLUME, updatedRange);
    }

    public void TextSpeedChanger(float updatedRange)
    {
        EventManager.EventTrigger(EventType.TEXTSPEED, updatedRange);
        _textSpeedDisplay.text = "Characters Per Second: " + updatedRange.ToString();
    }

    public void WindowChanger(int mode)
    {
        switch (mode)
        {
            case 0:
                //_fullscreenToggle.SetIsOnWithoutNotify(true);
                _largeResolutionToggle.SetIsOnWithoutNotify(false);
                _medResolutionToggle.SetIsOnWithoutNotify(false);
                _smallResolutionToggle.SetIsOnWithoutNotify(false);
                Screen.SetResolution(2048, 1536, true);
                _resolutionWidth = 2048;
                EventManager.EventTrigger(EventType.WINDOWRESOLUTION, _resolutionWidth);
                _fullscreenToggle.interactable = false;
                _largeResolutionToggle.interactable = true;
                _medResolutionToggle.interactable = true;
                _smallResolutionToggle.interactable = true;
            break;
            case 1:
                _fullscreenToggle.SetIsOnWithoutNotify(false);
                //_largeResolutionToggle.SetIsOnWithoutNotify(true);
                _medResolutionToggle.SetIsOnWithoutNotify(false);
                _smallResolutionToggle.SetIsOnWithoutNotify(false);
                Screen.SetResolution(2048, 1536, false);
                _resolutionWidth = 2048;
                EventManager.EventTrigger(EventType.WINDOWRESOLUTION, _resolutionWidth);
                _fullscreenToggle.interactable = true;
                _largeResolutionToggle.interactable = false;
                _medResolutionToggle.interactable = true;
                _smallResolutionToggle.interactable = true;
            break;
            case 2:
                _fullscreenToggle.SetIsOnWithoutNotify(false);
                _largeResolutionToggle.SetIsOnWithoutNotify(false);
                //_medResolutionToggle.SetIsOnWithoutNotify(true);
                _smallResolutionToggle.SetIsOnWithoutNotify(false);
                Screen.SetResolution(1440, 1080, false);
                _resolutionWidth = 1440;
                EventManager.EventTrigger(EventType.WINDOWRESOLUTION, _resolutionWidth);
                _fullscreenToggle.interactable = true;
                _largeResolutionToggle.interactable = true;
                _medResolutionToggle.interactable = false;
                _smallResolutionToggle.interactable = true;
            break;
            case 3:
                _fullscreenToggle.SetIsOnWithoutNotify(false);
                _largeResolutionToggle.SetIsOnWithoutNotify(false);
                _medResolutionToggle.SetIsOnWithoutNotify(false);
                //_smallResolutionToggle.SetIsOnWithoutNotify(true);
                Screen.SetResolution(1024, 768, false);
                _resolutionWidth = 1024;
                EventManager.EventTrigger(EventType.WINDOWRESOLUTION, _resolutionWidth);
                _fullscreenToggle.interactable = true;
                _largeResolutionToggle.interactable = true;
                _medResolutionToggle.interactable = true;
                _smallResolutionToggle.interactable = false;
            break;
        }
    }
}