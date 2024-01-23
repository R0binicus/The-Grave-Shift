using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, InputActions.IGameplayActions
{
    // Internal data
    private InputActions _inputs;
    private bool _canPause;
    private bool _debugging = false;

    void Awake()
    {
        _inputs = new InputActions();
        _inputs.Gameplay.SetCallbacks(this);

        EventManager.EventInitialise(EventType.PAUSE_TOGGLE);
        EventManager.EventInitialise(EventType.PLAYER_MOVE_BOOL);
        EventManager.EventInitialise(EventType.PLAYER_MOVE_VECT2D);
    }

    void OnEnable()
    {
        _inputs.Gameplay.Enable();
        EventManager.EventSubscribe(EventType.FADING, PauseAllowedHandler);
        EventManager.EventSubscribe(EventType.DEBUG_GAME, DebuggingHandler);
    }

    void OnDisable()
    {
        _inputs.Gameplay.Disable();
        EventManager.EventUnsubscribe(EventType.FADING, PauseAllowedHandler);
        EventManager.EventUnsubscribe(EventType.DEBUG_GAME, DebuggingHandler);
    }

    public void PauseAllowedHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("PauseAllowedHandler has not received a bool!!!");
        }

        _canPause = (bool)data;
    }

    public void DebuggingHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("DebuggingHandler has not received a bool!!!");
        }

        _debugging = (bool)data;
    }

    // If Esc is pressed
    public void OnPauseToggle(InputAction.CallbackContext context)
    {
        if (_canPause)
        {
            if (context.started)
            {
                //EventManager.EventTrigger(EventType.PAUSE_TOGGLE, null);
            }
        }
    }

    // If LeftMouse is pressed
    public void OnSelectClick(InputAction.CallbackContext context)
    {
        
    }
}
