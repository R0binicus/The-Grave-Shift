using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameplayUIManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject _speakerPanel;
    [SerializeField] private GameObject _soulSelectPanel;
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private GameObject _characterPanel;
    [SerializeField] private GameObject _questionsPanel;
    [SerializeField] private GameObject _decisionPanel;
    [SerializeField] private GameObject _quotaPanel;

    [Header("UI Objects")]
    [SerializeField] private GameObject _heavenButton;
    [SerializeField] private GameObject _hellbutton;
    [SerializeField] private GameObject _redPointer;
    [SerializeField] private Image _redPointerSprite;
    [SerializeField] private List<GameObject> _questionList;

    [Header("Sound")]
    [SerializeField] SoundType _nextDialogueSound;
    [SerializeField] SoundType _nextDialogueSound2;
    [SerializeField] SoundType _nextDialogueSound3;
    [SerializeField] SoundType _decisionBellSound;
    [SerializeField] SoundType _questionDialogueSound2;

    // Internal Data
    private TextMeshProUGUI _speakerText;
    private TextMeshProUGUI _dialogueText;
    private List<Button> _questionsButtons;
    private List<TextMeshProUGUI> _questionsText;
    private TextMeshProUGUI _quotaText;
    private int _hellQuota;

    // Typewriter data
    private int _currentCharacterIndex;
    private Coroutine _typewriterCoroutine;

    private WaitForSeconds _simpleDelay;
    private WaitForSeconds _interpunctuationWait;

    private LeanTweenType easeType = LeanTweenType.easeOutBounce;

    [Header("TypeWriter Settings")]
    [SerializeField] private float _charactersPerSec = 80;
    [SerializeField] private float _interpunctuationDelay = 0.5f;

    // Skipping functionality
    private bool _typewriterRunning = false;
    

    private void Awake()
    {
        InitUI();
        EventManager.EventInitialise(EventType.GAMEPLAYUI_NEXTLINE);

        _simpleDelay = new WaitForSeconds(1/_charactersPerSec);
        _interpunctuationWait = new WaitForSeconds(_interpunctuationDelay);
        _quotaText = _quotaPanel.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        EventManager.EventSubscribe(EventType.INTRO, IntroHandler);
        EventManager.EventSubscribe(EventType.DIALOGUE, DialogueHandler);
        EventManager.EventSubscribe(EventType.INK_LINES, LineHandler);
        EventManager.EventSubscribe(EventType.SOULSELECT, SoulSelectHandler);
        EventManager.EventSubscribe(EventType.DECISION, DecisionHandler);
        EventManager.EventSubscribe(EventType.INK_QUESTIONS, QuestionsHandler);
        EventManager.EventSubscribe(EventType.SENDSETTING, SettingsSendHandler);
        EventManager.EventSubscribe(EventType.QUOTA, QuotaHandler);
        EventManager.EventSubscribe(EventType.END, EndHandler);
        EventManager.EventSubscribe(EventType.QUOTASEND, QuotaSendHandler);
    }

    private void OnDisable()
    {
        EventManager.EventUnsubscribe(EventType.INTRO, IntroHandler);
        EventManager.EventUnsubscribe(EventType.DIALOGUE, DialogueHandler);
        EventManager.EventUnsubscribe(EventType.SOULSELECT, SoulSelectHandler);
        EventManager.EventUnsubscribe(EventType.INK_LINES, LineHandler);
        EventManager.EventUnsubscribe(EventType.DECISION, DecisionHandler);
        EventManager.EventUnsubscribe(EventType.INK_QUESTIONS, QuestionsHandler);
        EventManager.EventUnsubscribe(EventType.SENDSETTING, SettingsSendHandler);
        EventManager.EventUnsubscribe(EventType.QUOTA, QuotaHandler);
        EventManager.EventUnsubscribe(EventType.END, EndHandler);
        EventManager.EventUnsubscribe(EventType.QUOTASEND, QuotaSendHandler);
    }

    private void Start()
    {
        EventManager.EventTrigger(EventType.REQUESTSETTING, "SPEED");
    }

    private void InitUI()
    {
        _speakerText = _speakerPanel.GetComponentInChildren<TextMeshProUGUI>();
        _dialogueText = _dialoguePanel.GetComponentInChildren<TextMeshProUGUI>();
        _questionsButtons = _questionsPanel.GetComponentsInChildren<Button>().ToList<Button>();

        _questionsText = new List<TextMeshProUGUI>();

        // Populate Question Buttons text
        for (int i = 0; i < _questionsButtons.Count; i++)
        {
            _questionsText.Add(_questionsButtons[i].GetComponentInChildren<TextMeshProUGUI>());
        }

        HideAllPanels();
    }

    #region DECISION UI
    public void MoveDecisionPointer(int destination)
    {
        LeanTween.cancel(_redPointer);
        if (destination == 1)
        {
            LeanTween.moveX(_redPointer, _heavenButton.transform.position.x, 1).setEase(easeType);
            
            Color fromColor = _redPointerSprite.color;
            Color toColor = Color.HSVToRGB(240/360f, 1f, 1f);
            LeanTween.value( _redPointer, setColorCallback, fromColor, toColor, 0.625f );
        }
        else if (destination == 2)
        {
            LeanTween.moveX(_redPointer, _hellbutton.transform.position.x, 1).setEase(easeType);

            Color fromColor = _redPointerSprite.color;
            Color toColor = Color.HSVToRGB(0/360f, 1f, 1f);
            LeanTween.value( _redPointer, setColorCallback, fromColor, toColor, 0.625f );
        }
        else
        {
            LeanTween.moveX(_redPointer, _decisionPanel.transform.position.x, 2);

            Color fromColor = _redPointerSprite.color;
            Color toColor = Color.HSVToRGB(0/360f, 0f, 1f);
            LeanTween.value( _redPointer, setColorCallback, fromColor, toColor, 1.25f );
        }
    }

    private void setColorCallback( Color c )
    {
        _redPointerSprite.color = c;
    }
    #endregion

    #region BUTTONS
    public void NextLineButton()
    {
        if (_typewriterRunning == true)
        {
            Skip();
        }
        else
        {
            System.Random r = new System.Random();
            int rInt = r.Next(1, 4);
            switch(rInt) 
            {
                case 1:
                    EventManager.EventTrigger(EventType.SFX, _nextDialogueSound);
                    break;
                case 2:
                    EventManager.EventTrigger(EventType.SFX, _nextDialogueSound2);
                    break;
                case 3:
                    EventManager.EventTrigger(EventType.SFX, _nextDialogueSound3);
                    break;
                default:
                    Debug.LogError("RANDOM NUMBER NOT IN RANGE");
                    break;
            }
            EventManager.EventTrigger(EventType.GAMEPLAYUI_NEXTLINE, null);
        }
    }

    public void QuestionSelectedButton(int question)
    {
        _questionsPanel.SetActive(false);
        _dialoguePanel.SetActive(true);
        EventManager.EventTrigger(EventType.GAMEPLAYUI_QUESTIONSELECTED, question);
        GameObject activatedButton = _questionList[question];
        activatedButton.GetComponent<Button>().enabled = false;
        activatedButton.GetComponentInChildren<TextMeshProUGUI>().color = Color.HSVToRGB(0/360f, 0f, 0.5f);
    }

    public void ResetQuestions()
    {
        foreach (var question in _questionList)
        {
            GameObject activatedButton = question;
            activatedButton.GetComponent<Button>().enabled = true;
            activatedButton.GetComponentInChildren<TextMeshProUGUI>().color = Color.HSVToRGB(0/360f, 0f, 1f);
        }
    }

    public void HeavenButton()
    {
        EventManager.EventTrigger(EventType.SOULSELECT, SoulStatus.HEAVEN);
        LeanTween.moveX(_redPointer, _decisionPanel.transform.position.x, .25f);
        Color fromColor = _redPointerSprite.color;
        Color toColor = Color.HSVToRGB(0/360f, 0f, 1f);
        LeanTween.value( _redPointer, setColorCallback, fromColor, toColor, .25f );
        ResetQuestions();
    }

    public void HellButton()
    {
        EventManager.EventTrigger(EventType.SOULSELECT, SoulStatus.HELL);
        LeanTween.moveX(_redPointer, _decisionPanel.transform.position.x, .25f);
        Color fromColor = _redPointerSprite.color;
        Color toColor = Color.HSVToRGB(0/360f, 0f, 1f);
        LeanTween.value( _redPointer, setColorCallback, fromColor, toColor, .25f );
        ResetQuestions();
    }
    #endregion

    #region HANDLERS
    public void IntroHandler(object data)
    {
        ShowDialoguePanel();
    }

    public void DialogueHandler(object data)
    {
        ShowDialoguePanel();
    }

    public void SoulSelectHandler(object data)
    {
        ShowSoulSelectPanel();
    }

    public void LineHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("TextSendHandler hasn't received an InkData");
        }

        InkData currentSpeaker = (InkData)data;
        
        // Decide whether to show the speaker panel or not and fancify the first letter
        SpeakerPanel(currentSpeaker.Speaker);

        //Typewriter stuff
        if (_typewriterCoroutine != null)
        {
            _typewriterRunning = false;
            StopCoroutine(_typewriterCoroutine);
        }
        _dialogueText.text = currentSpeaker.Line;
        _dialogueText.maxVisibleCharacters = 0;
        _currentCharacterIndex = 0;

        _typewriterRunning = true;
        _typewriterCoroutine = StartCoroutine(Typewriter());
    }

    public void QuestionsHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("QuestionsHandler did not receive Questions!");
        }

        List<Choice> questions = (List<Choice>)data;

        _speakerText.text = "Questions";

        if (questions.Count > _questionsText.Count)
        {
            Debug.LogError("There are more questions than question buttons!");
        }

        for (int i = 0; i < _questionsText.Count; i++)
        {
            _questionsText[i].text = questions[i].text;
        }

        ShowQuestionsPanel();
    }

    public void DecisionHandler(object data)
    {
        _dialogueText.text = "";

        foreach (TextMeshProUGUI text in _questionsText)
        {
            text.text = "";
        }

        ShowDecisionPanel();
    }

    public void QuotaHandler(object data)
    {
        Debug.Log("yes");
        if (data == null)
        {
            Debug.LogError("QuotaHandler did not receive Questions!");
        }

        int soulsInHell = (int)data;

        if (soulsInHell >= _hellQuota)
        {
            _quotaText.text = "Quota was met...";
        }
        else 
        {
            _quotaText.text = "Quota was NOT met...";
        }

        ShowQuotaPanel();
    }

    public void QuotaSendHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("QuotaSendHandler did not receive Questions!");
        }

        _hellQuota = (int)data;
    }

    public void EndHandler(object data)
    {
        //ShowDialoguePanel();
    }

    public void SettingsSendHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("SettingsSendHandler is null!");
        }

        _charactersPerSec = (float)data;
        _simpleDelay = new WaitForSeconds(1/_charactersPerSec);
        _interpunctuationWait = new WaitForSeconds(_interpunctuationDelay);
    }
    #endregion

    #region PANELS
    private void HideAllPanels()
    {
        _speakerPanel.SetActive(false);
        _dialoguePanel.SetActive(false);
        _characterPanel.SetActive(false);
        _questionsPanel.SetActive(false);
        _soulSelectPanel.SetActive(false);
        _decisionPanel.SetActive(false);
        _quotaPanel.SetActive(false);
    }
    private void ShowDialoguePanel()
    {
        HideAllPanels();
        _speakerPanel.SetActive(true);
        _dialoguePanel.SetActive(true);
        _characterPanel.SetActive(true);
    }

    private void SpeakerPanel(string name)
    {
        _speakerText.text = FancyFirstLetter(name);

        if (_speakerText.text == "")
        {
            _speakerPanel.SetActive(false);
        }
        else
        {
            _speakerPanel.SetActive(true);
        }
    }

    private void ShowQuestionsPanel()
    {
        HideAllPanels();
        _speakerPanel.SetActive(true);
        _dialoguePanel.SetActive(true);
        _questionsPanel.SetActive(true);
    }

    private void ShowSoulSelectPanel()
    {
        HideAllPanels();
        _soulSelectPanel.SetActive(true);
    }

    private void ShowDecisionPanel()
    {
        HideAllPanels();
        _decisionPanel.SetActive(true);
    }

    private void ShowQuotaPanel()
    {
        HideAllPanels();
        _quotaPanel.SetActive(true);
        _speakerPanel.SetActive(true);
        _dialoguePanel.SetActive(true);
    }
    #endregion

    #region TYPEWRITER
    private IEnumerator Typewriter()
    {
        TMP_TextInfo textInfo = _dialogueText.textInfo;
        yield return new WaitForSeconds(0.1f);
    
        while (_currentCharacterIndex < textInfo.characterCount)
        {
            char character = textInfo.characterInfo[_currentCharacterIndex].character;

            _dialogueText.maxVisibleCharacters++;

            if (character == '?' || character == '.' || character == ',' || character == ':' ||
                     character == ';' || character == '!' || character == '-') 
            {
                yield return _interpunctuationDelay;
            }
            else
            {
                yield return _simpleDelay;
            }

            _currentCharacterIndex++;
        }
        _typewriterRunning = false;
        yield return null;
    }

    private void Skip()
    {
        _typewriterRunning = false;
        StopCoroutine(_typewriterCoroutine);
        _dialogueText.maxVisibleCharacters = _dialogueText.textInfo.characterCount;
    }
    #endregion
    
    private string FancyFirstLetter(string name)
    {
        switch(name)
        {
            case "gravedigger":
                return "<font=\"Olde English Regular SDF\">G</font>ravedigger";
            case "grim":
                return "<font=\"Olde English Regular SDF\">C</font>hurch Grim";
            case "soul":
                return "<font=\"Olde English Regular SDF\">S</font>oul";
            default:
                return "";
        }   
    }
    public void QuestionDialogueSound()
    {
        EventManager.EventTrigger(EventType.SFX, _questionDialogueSound2);
    }
    public void DecisionBellSound()
    {
        EventManager.EventTrigger(EventType.SFX, _decisionBellSound);
    }
}
