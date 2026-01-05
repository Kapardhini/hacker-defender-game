using UnityEngine;

public class AnswerHandler : MonoBehaviour
{
    // Drag your _GameManager object here in Inspector
    public GameManager gameManager;

    // We will link this function to the buttons
    public void ChooseAnswer(bool isCorrect)
    {
        if (gameManager != null)
        {
            gameManager.GameOver(isCorrect);
        }
    }
}