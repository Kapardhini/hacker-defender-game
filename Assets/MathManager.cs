using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class MathManager : MonoBehaviour
{
    // ================= CANVASES =================
    public GameObject hackerCanvas;
    public GameObject defenderCanvas;

    // ================= UI =================
    public GameObject start_Button;

    public TextMeshProUGUI hackerQuestionText;
    public TextMeshProUGUI defenderQuestionText;

    // Hacker answer buttons
    public GameObject hackerAnswer1;
    public GameObject hackerAnswer2;
    public GameObject hackerAnswer3;

    // Defender answer buttons
    public GameObject defenderAnswer1;
    public GameObject defenderAnswer2;
    public GameObject defenderAnswer3;

    public GameObject alarmText;
    public TextMeshProUGUI resultText;

    // ================= GAME STATE =================
    bool isHackerTurn = true;
    int currentQuestionIndex = 0;
    int hackerScore = 0;
    int defenderScore = 0;

    // ================= QUESTIONS =================
    string[] questions =
    {
        "8 + 6 = ?",
        "15 - 5 = ?",
        "3 × 3 = ?",
        "8 × 2 = ?",
        "20 - 8 = ?"
    };

    int[] correctAnswers = { 14, 10, 9, 16, 12 };

    int[,] options =
    {
        {12, 14, 16},
        {10, 12, 8},
        {6, 9, 12},
        {14, 16, 18},
        {10, 12, 14}
    };

    // ================= START =================
    void Start()
    {
        Debug.Log("Game Loaded");

        hackerCanvas.SetActive(true);
        defenderCanvas.SetActive(false);

        start_Button.SetActive(true);

        hackerQuestionText.gameObject.SetActive(false);
        defenderQuestionText.gameObject.SetActive(false);

        HideAllButtons();

        alarmText.SetActive(false);
        resultText.gameObject.SetActive(false);
    }

    // ================= START GAME =================
    public void StartGame()
    {
        Debug.Log("START BUTTON CLICKED → Hacker Turn Begins");

        start_Button.SetActive(false);

        isHackerTurn = true;
        currentQuestionIndex = 0;

        hackerQuestionText.gameObject.SetActive(true);
        defenderQuestionText.gameObject.SetActive(false);

        ShowHackerButtons();
        LoadQuestion();
    }

    // ================= LOAD QUESTION =================
    void LoadQuestion()
    {
        if (currentQuestionIndex >= questions.Length)
        {
            EndTurn();
            return;
        }

        Debug.Log(
            (isHackerTurn ? "Hacker Question: " : "Defender Question: ") +
            questions[currentQuestionIndex]
        );

        if (isHackerTurn)
            hackerQuestionText.text = questions[currentQuestionIndex];
        else
            defenderQuestionText.text = questions[currentQuestionIndex];

        if (isHackerTurn)
        {
            SetButtonText(hackerAnswer1, options[currentQuestionIndex, 0]);
            SetButtonText(hackerAnswer2, options[currentQuestionIndex, 1]);
            SetButtonText(hackerAnswer3, options[currentQuestionIndex, 2]);
        }
        else
        {
            SetButtonText(defenderAnswer1, options[currentQuestionIndex, 0]);
            SetButtonText(defenderAnswer2, options[currentQuestionIndex, 1]);
            SetButtonText(defenderAnswer3, options[currentQuestionIndex, 2]);
        }
    }

    void SetButtonText(GameObject button, int value)
    {
        button.GetComponentInChildren<TextMeshProUGUI>().text = value.ToString();
    }

    // ================= CHECK ANSWER =================
    public void CheckAnswer()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;

        int selectedAnswer = int.Parse(
            clickedButton.GetComponentInChildren<TextMeshProUGUI>().text
        );

        Debug.Log("Answer Clicked: " + selectedAnswer);

        if (selectedAnswer == correctAnswers[currentQuestionIndex])
        {
            if (isHackerTurn)
            {
                hackerScore++;
                Debug.Log("Correct! Hacker Score = " + hackerScore);
            }
            else
            {
                defenderScore++;
                Debug.Log("Correct! Defender Score = " + defenderScore);
            }
        }
        else
        {
            Debug.Log("Wrong Answer");
        }

        currentQuestionIndex++;
        LoadQuestion();
    }

    // ================= END TURN =================
    void EndTurn()
    {
        Debug.Log(isHackerTurn
            ? "Hacker Turn Ended"
            : "Defender Turn Ended");

        HideAllButtons();
        hackerQuestionText.gameObject.SetActive(false);
        defenderQuestionText.gameObject.SetActive(false);

        alarmText.SetActive(true);

        if (isHackerTurn)
            Invoke(nameof(StartDefenderTurn), 2f);
        else
            Invoke(nameof(EndGame), 2f);
    }

    // ================= DEFENDER TURN =================
    void StartDefenderTurn()
    {
        Debug.Log("DEFENDER TURN STARTED");

        isHackerTurn = false;
        currentQuestionIndex = 0;

        hackerCanvas.SetActive(false);
        defenderCanvas.SetActive(true);

        alarmText.SetActive(false);

        defenderQuestionText.gameObject.SetActive(true);
        ShowDefenderButtons();

        LoadQuestion();
    }

    // ================= GAME END =================
    void EndGame()
    {
        Debug.Log("GAME OVER");
        Debug.Log("FINAL SCORES → Hacker: " + hackerScore +
                  " | Defender: " + defenderScore);

        alarmText.SetActive(false);
        resultText.gameObject.SetActive(true);

        resultText.text =
            "Hacker: " + hackerScore +
            "\nDefender: " + defenderScore;
    }

    // ================= HELPERS =================
    void HideAllButtons()
    {
        hackerAnswer1.SetActive(false);
        hackerAnswer2.SetActive(false);
        hackerAnswer3.SetActive(false);

        defenderAnswer1.SetActive(false);
        defenderAnswer2.SetActive(false);
        defenderAnswer3.SetActive(false);
    }

    void ShowHackerButtons()
    {
        hackerAnswer1.SetActive(true);
        hackerAnswer2.SetActive(true);
        hackerAnswer3.SetActive(true);

        defenderAnswer1.SetActive(false);
        defenderAnswer2.SetActive(false);
        defenderAnswer3.SetActive(false);
    }

    void ShowDefenderButtons()
    {
        hackerAnswer1.SetActive(false);
        hackerAnswer2.SetActive(false);
        hackerAnswer3.SetActive(false);

        defenderAnswer1.SetActive(true);
        defenderAnswer2.SetActive(true);
        defenderAnswer3.SetActive(true);
    }
}
