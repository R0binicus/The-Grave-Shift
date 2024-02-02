using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum SoulStatus
{
    UNJUDGED,
    JUDGING,
    HEAVEN,
    HELL
}

public class SoulsManager : MonoBehaviour
{
    [Header("Souls Parent Object")]
    [SerializeField] private GameObject _soulsParent;

    private List<Soul> _souls;
    private Soul _currentSoul;

    private void Awake()
    {
        SoulsSetup();
    }

    private void OnEnable()
    {
        EventManager.EventSubscribe(EventType.SOULSELECT, SoulSelectHandler);
        EventManager.EventSubscribe(EventType.DIALOGUE, DialogueHandler);
    }

    private void OnDisable()
    {
        EventManager.EventUnsubscribe(EventType.SOULSELECT, SoulSelectHandler);
        EventManager.EventUnsubscribe(EventType.DIALOGUE, DialogueHandler);
    }

    public void SoulsSetup()
    {
        // Collect all souls and make into list
        _souls = _soulsParent.GetComponentsInChildren<Soul>().ToList<Soul>();

        // Assign this manager to each soul
        foreach (Soul soul in _souls)
        {
            soul.SetManager(this);
        }
    }

    public void SoulSelected(Soul soul)
    {   
        _currentSoul = soul;
        EventManager.EventTrigger(EventType.DIALOGUE, _currentSoul.Script);
    }

    public void SoulSelectHandler(object data)
    {
        // If last soul has been judged, set its status
        if (data != null)
        {
            _currentSoul.SetStatus((SoulStatus)data);
        }

        if (IsFinishedJudging())
        {
            // Make sure all souls are not interactable before moving on to ending
            ToggleInteractableSouls(false);
            EventManager.EventTrigger(EventType.QUOTA, SoulsInHell());
        }
        // Have all unjudged souls be available to interact with
        else
        {
            ToggleInteractableSouls(true);
        }
    }

    public void DialogueHandler(object data)
    {
        // Make sure no souls are interactable
        ToggleInteractableSouls(false);
    }

    public void ToggleInteractableSouls(bool toggle)
    {
        foreach (Soul soul in _souls)
        {
            soul.Interactable(toggle);
        }
    }

    public bool IsFinishedJudging()
    {
        foreach (Soul soul in _souls)
        {
            if (soul.Status == SoulStatus.UNJUDGED)
            {
                return false;
            }
        }

        return true;
    }

    public int SoulsInHell()
    {
        int hellSouls = 0;

        foreach (Soul soul in _souls)
        {
            if (soul.Status == SoulStatus.HELL)
            {
                hellSouls++;
            }
        }

        return hellSouls;
    }
}
