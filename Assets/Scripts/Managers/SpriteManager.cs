using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    [Header("Characters")]
    [SerializeField] private Character _churchGrim;
    [SerializeField] private Character _graveDigger;
    [SerializeField] private Character _soul;

    // Internal Data
    private Dictionary<string, Character> _characters;

    private void Awake()
    {
        _characters.Add("grim", _churchGrim);
        _characters.Add("gravedigger", _graveDigger);
        _characters.Add("soul", _soul);
    }

    private void OnEnable()
    {
        //EventManager.EventSubscribe(EventType.DIALOGUE, );
    }

    private void OnDisable()
    {
        //EventManager.EventUnsubscribe(EventType.DIALOGUE, );
    }

    public void HideAllCharacters()
    {
        foreach (KeyValuePair<string, Character> character in _characters)
        {
            character.Value.gameObject.SetActive(false);
        }
    }
}
