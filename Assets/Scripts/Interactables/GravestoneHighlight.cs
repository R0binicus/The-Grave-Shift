using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GravestoneHighlight : MonoBehaviour
{
    [SerializeField] private Light2D _spotlight; 
    private float _initialIntensity; 
    private Soul _soul;
    private bool _judged = false;

    [Header("Sound")]
    [SerializeField] SoundType _nextDialogueSound;
    
    void Awake()
    {
        _initialIntensity = _spotlight.intensity;
        _spotlight.intensity = 0;
        _soul = GetComponent<Soul>();
    }

    private void OnEnable()
    {
        EventManager.EventSubscribe(EventType.SOULSELECT, SoulSelectHandler);
    }

    private void OnDisable()
    {
        EventManager.EventUnsubscribe(EventType.SOULSELECT, SoulSelectHandler);
    }

    void OnMouseEnter()
    {
        if (!_judged)
        {
            LeanTween.cancel(gameObject);
            LeanTween.value(gameObject, UpdateLight, _spotlight.intensity, _initialIntensity, 1f);
        }
    }

    void OnMouseDown()
    {
        if (!_judged)
        {
            _soul.SelectedToJudge();
            EventManager.EventTrigger(EventType.SFX, _nextDialogueSound);
        }
    }

    void OnMouseExit()
    {
        if (!_judged)
        {
            LeanTween.cancel(gameObject);
            LeanTween.value(gameObject, UpdateLight, _spotlight.intensity, 0f, 0.5f);
        }
    }

    private void UpdateLight(float newValue)
    {
        _spotlight.intensity = newValue;
    }

    public void Judged(bool toggle)
    {
        _judged = toggle;
        Debug.Log(_soul.Status);
        if (_soul.Status == SoulStatus.HELL)
        {
            _spotlight.color = Color.HSVToRGB(0f/360f, 1, 1f);
        }
        else if (_soul.Status == SoulStatus.HEAVEN)
        {
            _spotlight.color = Color.HSVToRGB(240f/360f, 1, 1f);
        }
    }

    public void SoulSelectHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("SoulSelectHandler is null!");
        }
        
        SoulStatus staus = (SoulStatus)data;

        if (_soul.Status != SoulStatus.UNJUDGED)
        {
            if (_soul.Status == SoulStatus.HELL)
            {
                _spotlight.color = Color.HSVToRGB(0f/360f, 1, 1f);
            }
            else if (_soul.Status == SoulStatus.HEAVEN)
            {
                _spotlight.color = Color.HSVToRGB(240f/360f, 1, 1f);
            }
        }
    }
}
