using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GravestoneButton : MonoBehaviour
{
    [SerializeField] private Light2D _spotlight; 
    private float _initialIntensity; 
    [SerializeField] private int _code = 0;
    
    void Awake()
    {
        _initialIntensity = _spotlight.intensity;
        _spotlight.intensity = 0;
    }

    void OnMouseEnter()
    {
        LeanTween.cancel(gameObject);
        LeanTween.value(gameObject, updateLight, _spotlight.intensity, _initialIntensity, 1f);
    }

    void OnMouseDown()
    {
        EventManager.EventTrigger(EventType.MAINMENUEVENT, _code);
    }

    void OnMouseExit()
    {
        LeanTween.cancel(gameObject);
        LeanTween.value( gameObject, updateLight, _spotlight.intensity, 0f, 0.5f);
    }

    private void updateLight(float newValue)
    {
        _spotlight.intensity = newValue;
    }
}
