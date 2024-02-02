using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    [field: Header("Script")]
    [field: SerializeField] public TextAsset Script { get; private set; }

    // Internal Data
    public SoulStatus Status { get; private set; } = SoulStatus.UNJUDGED;

    private GravestoneHighlight _graveHighlight;
    private SoulsManager _manager;

    private void Awake()
    {
        _graveHighlight = GetComponent<GravestoneHighlight>();
    }

    public void SetManager(SoulsManager manager)
    {
        _manager = manager;
    }

    public void SelectedToJudge()
    {
        SetStatus(SoulStatus.JUDGING);
        _graveHighlight.Interactable(false);
        _manager.SoulSelected(this);
    }

    // Set a Soul's judged status
    public void SetStatus(SoulStatus status)
    {
        Status = status;
        _graveHighlight.ChangeHighlightColour();
    }

    public void Interactable(bool toggle)
    {
        if (toggle)
        {
            // Make sure already judged souls are not interactable
            if (Status == SoulStatus.UNJUDGED)
            {
                _graveHighlight.Interactable(toggle);
            }
        }
        else 
        {
            _graveHighlight.Interactable(toggle);
        }
    }
}
