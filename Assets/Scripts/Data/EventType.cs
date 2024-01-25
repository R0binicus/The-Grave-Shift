public enum EventType
{
    // SceneManagement           
    QUIT_LEVEL,             
    FADING,
    LEVEL_SELECTED,
    LEVEL_STARTED,
    LEVEL_ENDED,
    QUIT_GAME,

    // Music and sound
    SFX,
    MUSIC,
    STOP_MUSIC,
    PAUSE_MUSIC,
    MUTEMUSIC_TOGGLE,

    // Debugging
    DEBUG_GAME,

    // Game States
    INTRO,
    SOULSELECT,
    DIALOGUE,
    QUESTIONS,
    DECISION,
    END,
    PAUSE_TOGGLE,    

    // Intro
    INTRO_GAMEPLAYUI,
    INTRO_INK,
    // Soul Select

    // Dialogue

    // Questions

    // Decisions

    // End
};