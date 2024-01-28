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

    #region Init

    private void Awake()
    {
        EventManager.EventInitialise(EventType.MAINMENUEVENT);
        EventManager.EventInitialise(EventType.REQUESTSETTING);
        EventManager.EventInitialise(EventType.SENDSETTING);
        EventManager.EventInitialise(EventType.SFXVOLUME);
        EventManager.EventInitialise(EventType.MUSICVOLUME);
        EventManager.EventInitialise(EventType.TEXTSPEED);
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

        _receiver = "SFX";
        EventManager.EventTrigger(EventType.REQUESTSETTING, _receiver);

        //_sfxSlider.value = ;
        //_musicSlider.value = ;
        if(Screen.fullScreen == true)
        {
            _fullscreenToggle.SetIsOnWithoutNotify(true);
        }
        else 
        { 
           _fullscreenToggle.SetIsOnWithoutNotify(false);
        }

        foreach (var child in transform)
        {
            
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
        
        float setting = (float)data;
        Debug.Log(_receiver);
        Debug.Log(setting);
        if (_receiver == "SFX")
        {
            _receiver = "MUSIC";
            _sfxSlider.value = setting;
            EventManager.EventTrigger(EventType.REQUESTSETTING, _receiver);
        }
        else if (_receiver == "MUSIC")
        {
            _receiver = "SPEED";
            _musicSlider.value = setting;
            EventManager.EventTrigger(EventType.REQUESTSETTING, _receiver);
        }
        else if (_receiver == "SPEED")
        {
            _textSpeedSlider.value = setting;
        }
        else
        {
            Debug.Log("WTF SettingsSendHandler");
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
    public void SFXChanger(float UpdatedRange)
    {
        EventManager.EventTrigger(EventType.SFXVOLUME, UpdatedRange);
    }

    public void MusicChanger(float UpdatedRange)
    {
        EventManager.EventTrigger(EventType.MUSICVOLUME, UpdatedRange);
    }

    public void TextSpeedChanger(float UpdatedRange)
    {
        EventManager.EventTrigger(EventType.TEXTSPEED, UpdatedRange);
        _textSpeedDisplay.text = UpdatedRange.ToString();
    }
}