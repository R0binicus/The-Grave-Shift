using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameplayUIManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject _speakerPanel;
    [SerializeField] private GameObject _soulSelectPanel;
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private GameObject _questionsPanel;
    [SerializeField] private GameObject _decisionPanel;

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
        EventManager.EventSubscribe(EventType.INTRO, IntroHandler);
        EventManager.EventSubscribe(EventType.DIALOGUE, DialogueHandler);
        EventManager.EventSubscribe(EventType.INK_LINES, LineHandler);
        EventManager.EventSubscribe(EventType.SOULSELECT, SoulSelectHandler);
        EventManager.EventSubscribe(EventType.DECISION, DecisionHandler);
        EventManager.EventSubscribe(EventType.INK_QUESTIONS, QuestionsHandler);
    }

    private void OnDisable()
    {
        EventManager.EventUnsubscribe(EventType.INTRO, IntroHandler);
        EventManager.EventUnsubscribe(EventType.DIALOGUE, DialogueHandler);
        EventManager.EventUnsubscribe(EventType.SOULSELECT, SoulSelectHandler);
        EventManager.EventUnsubscribe(EventType.INK_LINES, LineHandler);
        EventManager.EventUnsubscribe(EventType.DECISION, DecisionHandler);
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
        _soulSelectPanel.SetActive(false);
        _decisionPanel.SetActive(false);
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

    public void HeavenButton()
    {
        EventManager.EventTrigger(EventType.SOULSELECT, SoulStatus.HEAVEN);
    }

    public void HellButton()
    {
        EventManager.EventTrigger(EventType.SOULSELECT, SoulStatus.HELL);
    }
    #endregion

    #region HANDLERS
    public void IntroHandler(object data)
    {
        _soulSelectPanel.SetActive(false);
        _speakerPanel.SetActive(true);
        _dialoguePanel.SetActive(true);
        _decisionPanel.SetActive(false);
    }

    public void DialogueHandler(object data)
    {
        _soulSelectPanel.SetActive(false);
        _speakerPanel.SetActive(true);
        _dialoguePanel.SetActive(true);
        _decisionPanel.SetActive(false);
    }

    public void SoulSelectHandler(object data)
    {
        _speakerPanel.SetActive(false);
        _dialoguePanel.SetActive(false);
        _soulSelectPanel.SetActive(true);
        _decisionPanel.SetActive(false);
    }

    public void LineHandler(object data)
    {
        if (data == null)
        {
            Debug.LogError("TextSendHandler hasn't received an InkData");
        }

        InkData dialogue = (InkData)data;
        _speakerText.text = dialogue.Speaker;
        _dialogueText.text = dialogue.Line;
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

    public void DecisionHandler(object data)
    {
        _dialogueText.text = "";

        foreach (TextMeshProUGUI text in _questionsText)
        {
            text.text = "";
        }

        _speakerPanel.SetActive(false);
        _dialoguePanel.SetActive(false);
        _soulSelectPanel.SetActive(false);
        _decisionPanel.SetActive(true);
    }
    #endregion
}
