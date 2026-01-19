using UnityEngine;

public class UI_controller : MonoBehaviour
{
    public GameObject startButton;
    public GameObject answerButton1;
    public GameObject answerButton2;
    public GameObject answerButton3;

    public void StartGame()
    {
        startButton.SetActive(false);

        answerButton1.SetActive(true);
        answerButton2.SetActive(true);
        answerButton3.SetActive(true);
    }
}
