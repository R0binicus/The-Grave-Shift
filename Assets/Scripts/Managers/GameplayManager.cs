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
    private GameplayState _state;

    private void Awake()
    {
        EventManager.EventInitialise(EventType.INTRO);
    }

    private void Start()
    {
        Intro();
    }

    private void Intro()
    {
        _state = GameplayState.INTRO;
        EventManager.EventTrigger(EventType.INTRO, null);
    }
}
