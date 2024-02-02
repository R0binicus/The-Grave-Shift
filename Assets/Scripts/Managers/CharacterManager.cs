using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData
{
    public string Character;
    public bool Toggle;

    public CharacterData(string character, bool toggle)
    {   
        Character = character;
        Toggle = toggle;
    }
}

public class CharacterManager : MonoBehaviour
{
    [Header("Characters")]
    [SerializeField] private Character _churchGrim;
    [SerializeField] private Character _graveDigger;
    [SerializeField] private Character _soul;

    // Internal Data
    private Dictionary<string, Character> _characters;

    private void Awake()
    {
        _characters = new Dictionary<string, Character>();
        _characters.Add("grim", _churchGrim);
        _characters.Add("gravedigger", _graveDigger);
        _characters.Add("soul", _soul);
    }

    private void OnEnable()
    {
        EventManager.EventSubscribe(EventType.INK_TOGGLE_CHARACTER, ToggleCharacter);
        EventManager.EventSubscribe(EventType.INK_LINES, SetPortrait);
    }

    private void OnDisable()
    {
        EventManager.EventUnsubscribe(EventType.INK_TOGGLE_CHARACTER, ToggleCharacter);
        EventManager.EventUnsubscribe(EventType.INK_LINES, SetPortrait);
    }

    private void Start()
    {
        HideAllCharacters();
    }

    public void ToggleCharacter(object data)
    {
        if (data == null)
        {
            Debug.LogError("CharacterManager has not received CharacterData from InkManager!");
        }

        CharacterData characterState = (CharacterData)data;

        // Check if character exists, then toggle
        if (_characters.ContainsKey(characterState.Character))
        {
            _characters[characterState.Character].gameObject.SetActive(characterState.Toggle);
        }
    }

    public void SetPortrait(object data)
    {
        if (data == null)
        {
            Debug.LogError("CharacterManager has not received InkData from InkManager!");
        }

        InkData currentSpeaker = (InkData)data;
        // Check if character exists, then set portrait
        if (_characters.ContainsKey(currentSpeaker.Speaker))
        {
            _characters[currentSpeaker.Speaker].ShowExpression(currentSpeaker.Portrait);
        }
    }

    public void HideAllCharacters()
    {
        foreach (KeyValuePair<string, Character> character in _characters)
        {
            character.Value.gameObject.SetActive(false);
        }
    }
}
