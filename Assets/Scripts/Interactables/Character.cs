using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ShowExpression(string expression)
    {
        foreach (FacialExpressions face in _facialExpressions)
        {
            if (face.Name == expression)
            {
                _image.sprite = face.Sprite;
                return;
            }
        }

        DefaultExpression();
    } 

    public void DefaultExpression()
    {
        _image.sprite = _facialExpressions[0].Sprite;
    }  
}
