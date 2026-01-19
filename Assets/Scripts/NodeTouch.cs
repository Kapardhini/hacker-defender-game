using UnityEngine;
using UnityEngine.InputSystem; // Make sure this is here!

public class NodeTouch : MonoBehaviour
{
    public DefenderGameManager gameManager;

    void Update()
    {
        // Using the New Input System for the mouse
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            // Fixed the capital 'R' here
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("PATCHING VULNERABILITY: " + gameObject.name);
                    SecureThisNode();
                }
            }
        }
    }

    void SecureThisNode()
    {
        if (gameManager != null)
        {
            gameManager.NodeSecured();
            gameObject.SetActive(false);
        }
    }
}