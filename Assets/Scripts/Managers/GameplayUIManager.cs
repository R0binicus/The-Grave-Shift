using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject _speakerPanel;
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private GameObject _questionsPanel;
    [SerializeField] private GameObject _choicePanel;

    // Internal Data
    private TextMeshProUGUI _speakerText;
    private TextMeshProUGUI _dialogueText;
    private List<Button> _questionsButtons;
    private List<TextMeshProUGUI> _questionsText;

    private void Awake()
    {
        InitUI();
        EventManager.EventInitialise(EventType.GAMEPLAYUI_NEXTLINE);
    }

    private void OnEnable()
    {
        EventManager.EventSubscribe(EventType.INK_INTRO, IntroHandler);
        EventManager.EventSubscribe(EventType.INK_SPEAKER, SpeakerHandler);
        EventManager.EventSubscribe(EventType.INK_TEXTSEND, TextSendHandler);
        EventManager.EventSubscribe(EventType.INK_TEXTEND, TextEndHandler);
        EventManager.EventSubscribe(EventType.INK_QUESTIONS, QuestionsHandler);
    }

    private void OnDisable()
    {
        EventManager.EventUnsubscribe(EventType.INK_INTRO, IntroHandler);
        EventManager.EventUnsubscribe(EventType.INK_SPEAKER, SpeakerHandler);
        EventManager.EventUnsubscribe(EventType.INK_TEXTSEND, TextSendHandler);
        EventManager.EventUnsubscribe(EventType.INK_TEXTEND, TextEndHandler);
        EventManager.EventUnsubscribe(EventType.INK_QUESTIONS, QuestionsHandler);
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

        _speakerPanel.SetActive(false);
        _dialoguePanel.SetActive(false);
        _questionsPanel.SetActive(false);
    }


    #region BUTTONS
    public void NextLineButton()
    {
        EventManager.EventTrigger(EventType.GAMEPLAYUI_NEXTLINE, null);
    }

    public void QuestionSelectedButton(int question)
    {
        _questionsPanel.SetActive(false);
        _dialoguePanel.SetActive(true);
        EventManager.EventTrigger(EventType.GAMEPLAYUI_QUESTIONSELECTED, question);
    }
    #endregion

    #region HANDLERS
    public void IntroHandler(object data)
    {
        _speakerPanel.SetActive(true);
        _dialoguePanel.SetActive(true);
    }

    public void SpeakerHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("TextSendHandler hasn't received a string");
        }

        _speakerText.text = (string)data;
    }

    public void TextSendHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("TextSendHandler hasn't received a string");
        }

        _dialogueText.text = (string)data;
    }

    public void TextEndHandler(object data)
    {
        _dialogueText.text = "";

        foreach (TextMeshProUGUI text in _questionsText)
        {
            text.text = "";
        }
    }

    public void QuestionsHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("QuestionsHandler did not receive Questions!");
        }

        List<Choice> questions = (List<Choice>)data;

        _dialoguePanel.SetActive(false);
        _speakerText.text = "Questions";

        if (questions.Count > _questionsText.Count)
        {
            Debug.LogError("There are more questions than question buttons!");
        }

        for (int i = 0; i < _questionsText.Count; i++)
        {
            _questionsText[i].text = questions[i].text;
        }

        _questionsPanel.SetActive(true);
    }
    #endregion
}
