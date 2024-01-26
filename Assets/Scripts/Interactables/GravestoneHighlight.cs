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
    
    void Awake()
    {
        _initialIntensity = _spotlight.intensity;
        _spotlight.intensity = 0;
        _soul = GetComponent<Soul>();
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
    }
}
