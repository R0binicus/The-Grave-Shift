using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FacialExpressions
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
}

public class Character : MonoBehaviour
{
    [Header("Facial Expressions")]
    [SerializeField] private List<FacialExpressions> _facialExpressions;

    // Internal Data
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ShowExpression(string expression)
    {
        foreach (FacialExpressions face in _facialExpressions)
        {
            if (face.Name == expression)
            {
                _spriteRenderer.sprite = face.Sprite;
                return;
            }
        }
    }   
}
