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

    // GameplayUIManager
    GAMEPLAYUI_INTRO,
    GAMEPLAYUI_NEXTLINE,

    // InkManager
    INK_INTRO,
    INK_SPEAKER,
    INK_TEXTSEND,
    INK_TEXTEND
};