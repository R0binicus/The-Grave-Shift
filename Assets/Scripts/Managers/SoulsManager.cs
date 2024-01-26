using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        _soulsParent.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.EventSubscribe(EventType.SOULSELECT, SoulSelectHandler);
    }

    private void OnDisable()
    {
        EventManager.EventUnsubscribe(EventType.SOULSELECT, SoulSelectHandler);
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
        if (IsFinishedJudging())
        {
            _soulsParent.SetActive(false);
            EventManager.EventTrigger(EventType.END, null);
        }
        else
        {
            _soulsParent.SetActive(true);
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
}
