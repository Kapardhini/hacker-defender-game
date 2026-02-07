using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class HackerConsole : MonoBehaviour
{
    [Header("Panel Management")]
    public GameObject startPanel;
    public GameObject consolePanel;
    public GameObject winPanel;        // Drag your Win_Panel here
    public GameObject losePanel;       // Drag your Lose_Panel here

    [Header("UI & Timer")]
    public TMP_Text timerText;         // Drag your Timer_text here
    public TMP_Text displayField;
    public TMP_InputField inputField;
    public TMP_Text strikeDisplay;

    private float timeRemaining = 60f; // Set your desired game time
    private bool isTimerRunning = false;
    private int currentQuestionIndex = 0;
    private int strikes = 0;

    [System.Serializable]
    public struct Question
    {
        public string questionText;
        public string answer;
    }
    public List<Question> quizBank = new List<Question>();

    void Start()
    {
        startPanel.SetActive(true);
        consolePanel.SetActive(false);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        timerText.gameObject.SetActive(false); // Timer stays hidden at start
        Debug.Log("Hacker Console Initialized");
        inputField.Select(); // Forces the box to be 'clicked' as soon as the game starts
        inputField.ActivateInputField();
    }

    public void StartHackingGame()
    {
        startPanel.SetActive(false);
        consolePanel.SetActive(true);
        timerText.gameObject.SetActive(true); // Timer activates now
        isTimerRunning = true;
        ShowQuestion();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timerText.text = "TIME: " + Mathf.CeilToInt(timeRemaining).ToString();
            }
            else
            {
                GameOver(false); // Time ran out
            }
        }
    }

    public void CheckAnswer()
    {
        if (string.IsNullOrEmpty(inputField.text)) return;

        string playerInput = inputField.text.Trim().ToLower();
        string correctAnswer = quizBank[currentQuestionIndex].answer.ToLower();

        if (playerInput == correctAnswer)
        {
            currentQuestionIndex++;
            if (currentQuestionIndex < quizBank.Count) ShowQuestion();
            else GameOver(true); // All questions cleared
        }
        else
        {
            strikes++;
            strikeDisplay.text = "STRIKES: " + strikes + "/3";
            if (strikes >= 3) GameOver(false);
            else ResetInput();
        }
    }

    void ShowQuestion()
    {
        displayField.text = quizBank[currentQuestionIndex].questionText;
        ResetInput();
    }

    void ResetInput()
    {
        inputField.text = "";
        inputField.ActivateInputField();
    }

    void GameOver(bool won)
    {
        isTimerRunning = false;
        consolePanel.SetActive(false);
        timerText.gameObject.SetActive(false);

        if (won) winPanel.SetActive(true);
        else losePanel.SetActive(true);
    }
}