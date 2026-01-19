using UnityEngine;
using TMPro;

public class TextBlinker : MonoBehaviour
{
    private TMP_Text textMesh;

    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (textMesh != null)
        {
            // Makes the text pulse Red <-> White
            float t = Mathf.PingPong(Time.time * 3.0f, 1.0f);
            textMesh.color = Color.Lerp(Color.white, Color.red, t);
        }
    }
}