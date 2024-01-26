using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    [Header("Script")]
    [SerializeField] private TextAsset _soulText;

    public Judging Status { get; private set; } = Judging.UNJUDGED;

    public void SetStatus(Judging status)
    {
        Status = status;
    }
}
