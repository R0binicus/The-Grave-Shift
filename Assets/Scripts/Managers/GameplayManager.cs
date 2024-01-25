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
    [SerializeField] private TextAsset _introText;
    [SerializeField] private TextAsset _endText;

    private GameplayState _state;

    private void Awake()
    {
        EventManager.EventInitialise(EventType.INTRO_INK);
        EventManager.EventInitialise(EventType.INTRO_GAMEPLAYUI);
    }

    private void Start()
    {
        Intro();
    }

    private void Intro()
    {
        _state = GameplayState.INTRO;
        EventManager.EventTrigger(EventType.INTRO_INK, null);
        EventManager.EventTrigger(EventType.INTRO_GAMEPLAYUI, null);
    }
}
