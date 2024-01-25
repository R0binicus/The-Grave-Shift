using System.Collections.Generic;
using System.Linq;
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

    }

    private void OnDisable()
    {
        EventManager.EventUnsubscribe(EventType.INK_INTRO, IntroHandler);
        EventManager.EventUnsubscribe(EventType.INK_SPEAKER, SpeakerHandler);
        EventManager.EventUnsubscribe(EventType.INK_TEXTSEND, TextSendHandler);
        EventManager.EventUnsubscribe(EventType.INK_TEXTEND, TextEndHandler);

    }

    private void InitUI()
    {
        _speakerText = _speakerPanel.GetComponentInChildren<TextMeshProUGUI>();
        _dialogueText = _dialoguePanel.GetComponentInChildren<TextMeshProUGUI>();
        _questionsButtons = _questionsPanel.GetComponentsInChildren<Button>().ToList<Button>();

        _speakerPanel.SetActive(false);
        _dialoguePanel.SetActive(false);
        _questionsPanel.SetActive(false);
    }

    public void NextLineButton()
    {
        EventManager.EventTrigger(EventType.GAMEPLAYUI_NEXTLINE, null);
    }

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
    }

}
