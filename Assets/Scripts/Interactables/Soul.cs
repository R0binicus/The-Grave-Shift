using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    [field: Header("Script")]
    [field: SerializeField] public TextAsset Script { get; private set; }

    // Internal Data
    public SoulStatus Status { get; private set; } = SoulStatus.UNJUDGED;

    private GravestoneHighlight _grave;
    private SoulsManager _manager;

    private void Awake()
    {
        _grave = GetComponent<GravestoneHighlight>();
    }

    public void SetManager(SoulsManager manager)
    {
        _manager = manager;
    }

    public void SelectedToJudge()
    {
        SetStatus(SoulStatus.JUDGING);
        Judged(true);
        _manager.SoulSelected(this);
    }

    public void SetStatus(SoulStatus status)
    {
        Status = status;
    }

    public void Judged(bool toggle)
    {
        _grave.Judged(toggle);
    }
}
