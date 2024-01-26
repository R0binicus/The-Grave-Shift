using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Judging
{
    UNJUDGED,
    HEAVEN,
    HELL
}

public class SoulsManager : MonoBehaviour
{
    [Header("Souls Parent Object")]
    [SerializeField] private GameObject _soulsParent;

    private List<Soul> _souls;

    private void Awake()
    {
        // Collect all souls and make into list
        _souls = _soulsParent.GetComponentsInChildren<Soul>().ToList<Soul>();
    }

    public bool IsFinishedJudging()
    {
        foreach (Soul soul in _souls)
        {
            if (soul.Status == Judging.UNJUDGED)
            {
                return false;
            }
        }

        return true;
    }
}
