using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System;

public class InkData
{
    public string Speaker;
    public string Portrait;
    public string Line;

    public InkData(string speaker, string portrait, string line)
    {   
        Speaker = speaker;
        Portrait = portrait;
        Line = line;
    }
}

public class InkManager : MonoBehaviour
{
    private Story _currentScript;
    private InkData _currentSpeaker;
    private CharacterData _characterState;
    private GameplayState _state;

    // Ink Script Data
    private const string Action = "a:";
    private const string Character = "c:";
    private const string Portrait = "p:";

    private void Awake()
    {
        _currentSpeaker = new InkData("", "", "");
        _characterState = new CharacterData("", false);
        EventManager.EventInitialise(EventType.INK_TOGGLE_CHARACTER);
    }

    private void OnEnable()
    {
        EventManager.EventSubscribe(EventType.INTRO, IntroHandler);
        EventManager.EventSubscribe(EventType.DIALOGUE, DialogueHandler);
        EventManager.EventSubscribe(EventType.GAMEPLAYUI_NEXTLINE, NextLineHandler);
        EventManager.EventSubscribe(EventType.GAMEPLAYUI_QUESTIONSELECTED, QuestionSelectedHandler);
        EventManager.EventSubscribe(EventType.END, EndHandler);
    }

    private void OnDisable()
    {
        EventManager.EventUnsubscribe(EventType.INTRO, IntroHandler);
        EventManager.EventUnsubscribe(EventType.DIALOGUE, DialogueHandler);
        EventManager.EventUnsubscribe(EventType.GAMEPLAYUI_NEXTLINE, NextLineHandler);
        EventManager.EventUnsubscribe(EventType.GAMEPLAYUI_QUESTIONSELECTED, QuestionSelectedHandler);
        EventManager.EventUnsubscribe(EventType.END, EndHandler);
    }

    public void SetScript(TextAsset script)
    {
        _currentScript = new Story(script.text);
    }

    // Set the Ink script to process
    public void IntroHandler(object data)
    {
        _state = GameplayState.INTRO;

        if (data == null)
        {
            Debug.LogError("InkManager SetScript has not received a text file!");
        }

        TextAsset script = (TextAsset)data;
        SetScript(script);
        NextLineHandler(null);
    }

    public void EndHandler(object data)
    {
        _state = GameplayState.END;

        if (data == null)
        {
            Debug.LogError("InkManager SetScript has not received a text file!");
        }

        TextAsset script = (TextAsset)data;
        SetScript(script);
        NextLineHandler(null);
    }

    public void DialogueHandler(object data)
    {
        _state = GameplayState.DIALOGUE;
        TextAsset script = (TextAsset)data;
        SetScript(script);
        NextLineHandler(null);
    }

    public void NextLineHandler(object data)
    {
        // If there are lines to parse
        if (_currentScript.canContinue)
        {
            _currentSpeaker.Line = _currentScript.Continue();

            // If no questions are to be displayed, handle tags and send next text line
            if (_currentScript.currentChoices.Count == 0)
            {
                HandleTags(_currentScript.currentTags);
                EventManager.EventTrigger(EventType.INK_LINES, _currentSpeaker);
            }
            // Display questions
            else
            {
                EventManager.EventTrigger(EventType.INK_QUESTIONS, _currentScript.currentChoices);
            }
        }
        // If no more lines to parse, signal end of script
        else
        {
            if (_state == GameplayState.INTRO)
            {
                EventManager.EventTrigger(EventType.SOULSELECT, null);
            }
            else if (_state == GameplayState.END)
            {
                EventManager.EventTrigger(EventType.QUIT_LEVEL, null);
            }
            else 
            {
                EventManager.EventTrigger(EventType.DECISION, null);
            }
        }
    }

    public void QuestionSelectedHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("QuestionSelectedHandler has not received an int!");
        }

        _currentScript.ChooseChoiceIndex((int)data);
        NextLineHandler(null);
    }

    public void HandleTags(List<string> currentTags)
    {
        if (currentTags.Count != 0)
        {
            foreach (string tag in currentTags)
            {
                // If tag is an action
                if (tag.Contains(Action))
                {
                    if (tag.Contains("enter"))
                    {
                        _characterState.Character = tag.Remove(0, 8);
                        _characterState.Toggle = true;
                        EventManager.EventTrigger(EventType.INK_TOGGLE_CHARACTER, _characterState);
                    }
                    else if (tag.Contains("exit"))
                    {
                        _characterState.Character = tag.Remove(0, 7);
                        _characterState.Toggle = false;
                        EventManager.EventTrigger(EventType.INK_TOGGLE_CHARACTER, _characterState);
                    }
                    else if (tag.Contains("desc"))
                    {
                        _currentSpeaker.Speaker = "";
                    }
                }
                // If tag is a character
                else if (tag.Contains(Character))
                {
                    if (tag.Contains("grim") || tag.Contains("gravedigger"))
                    {
                        _currentSpeaker.Speaker = tag.Remove(0, 2);
                    }
                    else if (tag.Contains("nina") || tag.Contains("edward") || tag.Contains("diane")
                        || tag.Contains("maureen") || tag.Contains("kenneth"))
                    {
                        _currentSpeaker.Speaker = "soul";
                    }
                    else 
                    {
                        _currentSpeaker.Speaker = "";
                    }
                }
                // If tag is a portrait
                else if (tag.Contains(Portrait))
                {
                    // Remove p:
                    _currentSpeaker.Portrait = tag.Remove(0, 2);
                }
            }
        }
    }
}
