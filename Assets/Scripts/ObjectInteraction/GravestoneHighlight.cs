using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GravestoneHighlight : MonoBehaviour
{
    private float _initialIntensity; 
    [SerializeField] private Light2D _spotlight; 
    // Start is called before the first frame update
    void Awake()
    {
        _initialIntensity = _spotlight.intensity;
        _spotlight.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        LeanTween.cancel(gameObject);
        LeanTween.value( gameObject, updateLight, _spotlight.intensity, _initialIntensity, 1f );

    }

    void OnMouseExit()
    {
        LeanTween.cancel(gameObject);
        LeanTween.value( gameObject, updateLight, _spotlight.intensity, 0f, 0.5f );

    }

    private void updateLight(float newValue)
    {
        _spotlight.intensity = newValue;
    }
}
