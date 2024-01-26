using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    
    private void Awake()
    {
        EventManager.EventInitialise(EventType.SFXVOLUME);
        EventManager.EventInitialise(EventType.MUSICVOLUME);
        
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void SFXChanger(float UpdatedRange)
    {
        EventManager.EventTrigger(EventType.SFXVOLUME, UpdatedRange);
    }

    public void MusicChanger(float UpdatedRange)
    {
        EventManager.EventTrigger(EventType.MUSICVOLUME, UpdatedRange);
    }
}
