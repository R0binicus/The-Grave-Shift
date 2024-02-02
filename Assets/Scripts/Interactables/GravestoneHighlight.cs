using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GravestoneHighlight : MonoBehaviour
{
    [SerializeField] private Light2D _spotlight; 
    private float _initialIntensity; 
    private Soul _soul;
    private bool _interactable = false;

    [Header("Sound")]
    [SerializeField] SoundType _nextDialogueSound;
    
    void Awake()
    {
        _initialIntensity = _spotlight.intensity;
        _spotlight.intensity = 0;
        _soul = GetComponent<Soul>();
    }

    #region UI HANDLING
    void OnMouseEnter()
    {
        if (_interactable)
        {
            AnimateHighlight();
        }
    }

    void OnMouseDown()
    {
        if (_interactable)
        {
            _soul.SelectedToJudge();
            EventManager.EventTrigger(EventType.SFX, _nextDialogueSound);
        }
    }

    void OnMouseExit()
    {
        if (_interactable)
        {
            RemoveHighlight();
        }
    }
    #endregion

    #region LIGHT ANIMATION
    private void UpdateLight(float newValue)
    {
        _spotlight.intensity = newValue;
    }

    private void AnimateHighlight()
    {
        LeanTween.cancel(gameObject);
        LeanTween.value(gameObject, UpdateLight, _spotlight.intensity, _initialIntensity, 1f);
    }

    private void RemoveHighlight()
    {
        LeanTween.cancel(gameObject);
        LeanTween.value(gameObject, UpdateLight, _spotlight.intensity, 0f, 0.5f);
    }
    #endregion

    public void Interactable(bool toggle)
    {
        _interactable = toggle;
    }

    public void ChangeHighlightColour()
    {
        if (_soul.Status == SoulStatus.HELL)
        {
            _spotlight.color = Color.HSVToRGB(0f/360f, 1, 1f);
        }
        else if (_soul.Status == SoulStatus.HEAVEN)
        {
            _spotlight.color = Color.HSVToRGB(240f/360f, 1, 1f);
        }
        else 
        {
            _spotlight.color = Color.white;
        }
    }
}
