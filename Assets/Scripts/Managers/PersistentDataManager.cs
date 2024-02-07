using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{
    private float _charactersPerSec = 40;
    private int _resolutionWidth = 1440;

    private void Awake()
    {
        EventManager.EventInitialise(EventType.REQUESTSETTING);
        EventManager.EventInitialise(EventType.SENDSETTING);
    }
    private void OnEnable()
    {
        EventManager.EventSubscribe(EventType.REQUESTSETTING, SettingsRequestHandler);
        EventManager.EventSubscribe(EventType.TEXTSPEED, TextSpeedHandler);
        EventManager.EventSubscribe(EventType.WINDOWRESOLUTION, WindowResolutionHandler);
    }

    private void OnDisable()
    {
        EventManager.EventUnsubscribe(EventType.REQUESTSETTING, SettingsRequestHandler);
        EventManager.EventUnsubscribe(EventType.TEXTSPEED, TextSpeedHandler);
        EventManager.EventUnsubscribe(EventType.WINDOWRESOLUTION, WindowResolutionHandler);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingsRequestHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("SettingsRequestHandler is null!");
        }

        string setting = (string)data;

        if (setting == "MENU")
        {
            SettingsData tempSettings = new SettingsData(0f,0f,_charactersPerSec,_resolutionWidth);
            EventManager.EventTrigger(EventType.SENDSETTING, tempSettings);
        }
    }

    public void TextSpeedHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("TextSpeedHandler is null!");
        }

        _charactersPerSec = (float)data;
    }

    public void WindowResolutionHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("WindowResolutionHandler is null!");
        }

        _resolutionWidth = (int)data;
    }
}
