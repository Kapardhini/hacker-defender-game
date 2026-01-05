using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;
    public void Start()
    {
        // Make sure panels are hidden at start
        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);
    }
    public void GameOver(bool playerWon)
    {
        if (playerWon)
        {
            winPanel.SetActive(true);
            losePanel.SetActive(false); // Force the red panel to hide
        }
        else
        {
            losePanel.SetActive(true);
            winPanel.SetActive(false); // Force the green panel to hide
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}