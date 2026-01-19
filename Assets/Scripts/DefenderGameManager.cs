using UnityEngine;
using TMPro;

public class DefenderGameManager : MonoBehaviour
{
    [Header("Game Nodes")]
    public GameObject[] nodes;         // Drag your 5 spheres here
    public Material attackMaterial;    // Drag your 'Attacked_Red' material here

    [Header("UI Elements")]
    public TMP_Text timerText;         // Changed to TMP_Text for easier drag-and-drop
    public GameObject winText;         // Drag Win_Panel here
    public GameObject loseText;        // Drag Lose_Panel here

    private int currentNodeIndex = 0;
    private float timeLeft = 35f;
    private bool isGameActive = false;

    void Start()
    {
        if (winText != null) winText.SetActive(false);
        if (loseText != null) loseText.SetActive(false);
        foreach (var node in nodes) node.SetActive(false);
    }

    void Update()
    {
        if (isGameActive)
        {
            timeLeft -= Time.deltaTime;
            if (timerText != null)
                timerText.text = "Time: " + Mathf.Ceil(timeLeft).ToString();

            if (timeLeft <= 0) EndGame(false);
        }
    }

    public void StartTask()
    {
        isGameActive = true;
        timeLeft = 30f;
        currentNodeIndex = 0;

        if (winText != null) winText.SetActive(false);
        if (loseText != null) loseText.SetActive(false);

        SpawnNextNode();
    }

    void SpawnNextNode()
    {
        // Hide all nodes first
        foreach (var node in nodes) node.SetActive(false);

        if (currentNodeIndex < nodes.Length)
        {
            GameObject activeNode = nodes[currentNodeIndex];
            activeNode.SetActive(true);

            // NEW: Change the sphere's color to the Red Attack Material
            Renderer nodeRenderer = activeNode.GetComponent<Renderer>();
            if (nodeRenderer != null && attackMaterial != null)
            {
                nodeRenderer.material = attackMaterial;
            }
        }
        else
        {
            EndGame(true);
        }
    }

    public void NodeSecured()
    {
        if (!isGameActive) return;

        currentNodeIndex++;

        if (currentNodeIndex < nodes.Length)
        {
            // 1. GET THE NEXT OBJECT
            GameObject nextNode = nodes[currentNodeIndex];

            // 2. THE CRITICAL FIX: Wake it up in the hierarchy!
            nextNode.SetActive(true);

            // 3. Change the color so the player knows it's the target
            nextNode.GetComponent<Renderer>().material = attackMaterial;

            Debug.Log("Next node activated: " + nextNode.name);
        }
        else
        {
            EndGame(true);
        }
    }

    void EndGame(bool success)
    {
        isGameActive = false;
        foreach (var node in nodes) node.SetActive(false);

        if (success)
        {
            if (winText != null) winText.SetActive(true);
        }
        else
        {
            if (loseText != null) loseText.SetActive(true);
        }
    }
}