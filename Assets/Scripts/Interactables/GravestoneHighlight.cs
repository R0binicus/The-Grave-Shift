using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GravestoneHighlight : MonoBehaviour
{
    [SerializeField] private Light2D _spotlight; 
    private float _initialIntensity; 
    private Soul _soul;
    
    void Awake()
    {
        _initialIntensity = _spotlight.intensity;
        _spotlight.intensity = 0;
        _soul = GetComponent<Soul>();
    }

    void OnMouseEnter()
    {
        LeanTween.cancel(gameObject);
        LeanTween.value(gameObject, updateLight, _spotlight.intensity, _initialIntensity, 1f);
    }

    void OnMouseDown()
    {
        _soul.SelectedToJudge();
    }

    void OnMouseExit()
    {
        LeanTween.cancel(gameObject);
        LeanTween.value(gameObject, updateLight, _spotlight.intensity, 0f, 0.5f);
    }

    private void updateLight(float newValue)
    {
        _spotlight.intensity = newValue;
    }
}
