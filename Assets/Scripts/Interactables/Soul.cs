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
        ToggleGraveHighlight(true);
    }

    public void SetManager(SoulsManager manager)
    {
        _manager = manager;
    }

    public void SelectedToJudge()
    {
        SetStatus(SoulStatus.JUDGING);
        ToggleGraveHighlight(false);
        _manager.SoulSelected(this);
    }

    public void SetStatus(SoulStatus status)
    {
        Status = status;
    }

    public void ToggleGraveHighlight(bool toggle)
    {
        _grave.enabled = toggle;
    }
}
