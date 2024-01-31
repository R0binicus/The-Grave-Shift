using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{
    
    private float _charactersPerSec = 40;
    private void OnEnable()
    {
        EventManager.EventSubscribe(EventType.REQUESTSETTING, SettingsRequestHandler);
        EventManager.EventSubscribe(EventType.TEXTSPEED, TextSpeedHandler);
    }

    private void OnDisable()
    {
        EventManager.EventUnsubscribe(EventType.REQUESTSETTING, SettingsRequestHandler);
        EventManager.EventUnsubscribe(EventType.TEXTSPEED, TextSpeedHandler);
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

        if (setting == "SPEED")
        {
            EventManager.EventTrigger(EventType.SENDSETTING, _charactersPerSec);
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
}
