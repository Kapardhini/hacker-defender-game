using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.InputSystem; // Add this at the very top!

public class SequenceHacker : MonoBehaviour
{
    [Header("Game Objects")]
    public List<GameObject> nodes; // Drag your 3-5 spheres here IN ORDER
    public GameObject winPanel;
    public GameObject losePanel;

    [Header("UI")]
    public TMP_Text statusText;
    public TMP_Text timerText;

    private int currentStep = 0;
    private float timeLeft = 30f;
    private bool isGameActive = false;
    public GameObject startMenuCanvas; // The one with the Start button
    public GameObject consoleCanvas;
    void Start() => ResetGame();

    public void StartHacking()
    {
        Debug.Log("START BUTTON CLICKED!");

        // --- NEW: UI SWAP ---
        if (startMenuCanvas != null) startMenuCanvas.SetActive(false);
        if (consoleCanvas != null) consoleCanvas.SetActive(true);
        // --------------------

        isGameActive = true;
        timeLeft = 30f;
        currentStep = 0;

        if (nodes == null || nodes.Count == 0)
        {
            Debug.LogError("The Nodes list is EMPTY! Drag your spheres into the Inspector!");
            return;
        }

        foreach (GameObject node in nodes)
        {
            if (node != null)
            {
                node.SetActive(true);
                Debug.Log("Showing node: " + node.name);
            }
        }

        if (statusText != null) statusText.text = "START BREACH";
    }



    void Update()
{
    if (!isGameActive) return;

    // Handle Timer...
    if (timeLeft > 0)
    {
        timeLeft -= Time.deltaTime;
        timerText.text = "LOCKOUT: " + Mathf.CeilToInt(timeLeft);
    }

    // NEW INPUT SYSTEM CLICK CHECK
    if (Mouse.current.leftButton.wasPressedThisFrame)
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            CheckNode(hit.transform.gameObject);
        }
    }
}

void CheckNode(GameObject clickedNode)
    {
        // Is this the correct next node in the list?
        if (clickedNode == nodes[currentStep])
        {
            clickedNode.SetActive(false); // "Breached"
            currentStep++;
            statusText.text = $"NODE {currentStep} BYPASSED...";

            if (currentStep >= nodes.Count) EndGame(true);
        }
        else
        {
            // WRONG NODE - Reset the sequence!
            statusText.text = "ERROR: SEQUENCE RESET!";
            ResetSequence();
        }
    }

    void ResetSequence()
    {
        currentStep = 0;
        foreach (var node in nodes) node.SetActive(true);
    }

    void ResetGame()
    {
        isGameActive = false;
        timeLeft = 30f;
        ResetSequence();
        foreach (var node in nodes) node.SetActive(false); // Hide until Start
    }

    void EndGame(bool won)
    {
        isGameActive = false;
        if (won) winPanel.SetActive(true);
        else losePanel.SetActive(true);
    }
}