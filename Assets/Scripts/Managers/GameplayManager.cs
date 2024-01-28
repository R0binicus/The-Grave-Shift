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
    [SerializeField] private TextAsset _introText;
    [SerializeField] private TextAsset _endText;
    [Header("Quota")]
    [SerializeField] private int _hellQuota;

    private GameplayState _state;

    private void Awake()
    {
        EventManager.EventInitialise(EventType.INTRO);
        EventManager.EventInitialise(EventType.DIALOGUE);
        EventManager.EventInitialise(EventType.SOULSELECT);
        EventManager.EventInitialise(EventType.DECISION);
        EventManager.EventInitialise(EventType.END);
    }

    private void OnEnable()
    {
        EventManager.EventSubscribe(EventType.END, End);
    }

    private void OnDisable()
    {
        EventManager.EventUnsubscribe(EventType.END, End);
    }

    private void Start()
    {
        Intro();
    }

    private void Intro()
    {
        _state = GameplayState.INTRO;
        EventManager.EventTrigger(EventType.INTRO, _introText);
    }

    public void End(object data)
    {
        if (data == null)
        {
            Debug.LogError("GameplayManager has not received an int!");
        }

        int soulsInHell = (int)data;

        if (soulsInHell >= _hellQuota)
        {
            Debug.Log("QUOTA MET");
        }
        else 
        {
            Debug.Log("QUOTA NOT MET");
        }
    }
}
