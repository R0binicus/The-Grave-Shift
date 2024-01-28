using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkData
{
    public string Speaker;
    public string Line;

    public InkData(string speaker, string line)
    {   
        Speaker = speaker;
        Line = line;
    }
}

public class InkManager : MonoBehaviour
{
    private Story _currentScript;
    private InkData _dialogue;
    private GameplayState _state;

    private void Awake()
    {
        _dialogue = new InkData("", "");
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
        if (_currentScript.canContinue)
        {
            string line = _currentScript.Continue();

            // If no questions are to be displayed
            if (_currentScript.currentChoices.Count == 0)
            {
                string speaker = HandleTag(_currentScript.currentTags);

                _dialogue.Speaker = speaker;
                _dialogue.Line = line;
                EventManager.EventTrigger(EventType.INK_LINES, _dialogue);
            }
            // Display questions
            else
            {
                EventManager.EventTrigger(EventType.INK_QUESTIONS, _currentScript.currentChoices);
            }
        }
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

    public string HandleTag(List<string> currentTags)
    {
        if (currentTags.Count != 0)
        {
            string speaker = currentTags[0].Trim();
            switch(speaker)
            {
                case "gravedigger":
                    return "Gravedigger";
                case "grim":
                    return "Church Grim";
                case "nina":
                    return "Soul";
                case "edward":
                    return "Soul";
                case "diane":
                    return "Soul";
                case "maureen":
                    return "Soul";
                case "kenneth":
                    return "Soul";
                default:
                    return "";
            }
        }

        return null;
    }
}

