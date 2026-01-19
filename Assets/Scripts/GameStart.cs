using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject wholeCanvas; // NEW: Drag the 'Canvas' object here
    public DefenderGameManager terminalScript;

    public void OnStartClick()
    {
        if (startPanel != null) startPanel.SetActive(false);

        // This disables the whole Canvas so it doesn't block your mouse
        if (wholeCanvas != null) wholeCanvas.SetActive(false);

        if (terminalScript != null)
        {
            terminalScript.StartTask();
        }
    }
}