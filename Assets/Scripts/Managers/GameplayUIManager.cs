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
    }

    private void OnEnable()
    {
        EventManager.EventSubscribe(EventType.INTRO, IntroHandler);
    }

    private void OnDisable()
    {
        EventManager.EventUnsubscribe(EventType.INTRO, IntroHandler);
    }

    private void InitUI()
    {
        _speakerText = _speakerPanel.GetComponent<TextMeshProUGUI>();
        _dialogueText = _dialoguePanel.GetComponent<TextMeshProUGUI>();
        _questionsButtons = _questionsPanel.GetComponentsInChildren<Button>().ToList<Button>();

        _speakerPanel.SetActive(false);
        _dialoguePanel.SetActive(false);
        _questionsPanel.SetActive(false);
    }

    public void IntroHandler(object data)
    {
        _speakerPanel.SetActive(true);
        _dialoguePanel.SetActive(true);
    }

}
