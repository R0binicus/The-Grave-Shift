using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameplayState
{
    INTRO,
    SOULSELECT,
    DIALOGUE,
    QUESTIONS,
    DECISION,
    END
}

public class GameplayManager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private TextAsset _introScript;
    [SerializeField] private TextAsset _quotaMetScript;
    [SerializeField] private TextAsset _quotaNotMetScript;

    [Header("Quota")]
    [SerializeField] private int _hellQuota;

    // Internal Data
    private TextAsset _endScript;

    private void Awake()
    {
        EventManager.EventInitialise(EventType.INTRO);
        EventManager.EventInitialise(EventType.DIALOGUE);
        EventManager.EventInitialise(EventType.SOULSELECT);
        EventManager.EventInitialise(EventType.DECISION);
        EventManager.EventInitialise(EventType.QUOTA);
        EventManager.EventInitialise(EventType.END);
    }

    private void OnEnable()
    {
        EventManager.EventSubscribe(EventType.QUOTA, Quota);
    }

    private void OnDisable()
    {
        EventManager.EventUnsubscribe(EventType.QUOTA, Quota);
    }

    private void Start()
    {
        Intro();
    }

    private void Intro()
    {
        EventManager.EventTrigger(EventType.INTRO, _introScript);
    }

    public void Quota(object data)
    {
        if (data == null)
        {
            Debug.LogError("GameplayManager has not received an int!");
        }

        int soulsInHell = (int)data;

        if (soulsInHell >= _hellQuota)
        {
            _endScript = _quotaMetScript;
        }
        else 
        {
            _endScript = _quotaNotMetScript;
        }
    }

    private void End()
    {
        if (_endScript == null)
        {
            Debug.LogError("End script not assigned!");
        }

        EventManager.EventTrigger(EventType.END, _endScript);
    }
}
