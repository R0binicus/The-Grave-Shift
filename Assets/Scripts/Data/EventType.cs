public enum EventType
{
    PAUSE_TOGGLE,           // Broadcasts when pause is toggled on or off



    // SceneManagement           
    QUIT_LEVEL,             
    SCENE_LOAD,   
    FADING,
    SCENE_COUNT,
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
    END
};