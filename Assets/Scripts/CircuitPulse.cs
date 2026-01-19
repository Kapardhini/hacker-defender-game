using UnityEngine;

public class CircuitPulse : MonoBehaviour
{
    private Material circuitMat;
    [ColorUsage(true, true)] // Allows for HDR intensity
    public Color pulseColor = Color.cyan;
    public float pulseSpeed = 2.0f;
    public float minIntensity = 0.5f;
    public float maxIntensity = 3.0f;

    void Start()
    {
        // Get the material from the wall's renderer
        circuitMat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Calculate a smooth sine wave (0 to 1)
        float emission = minIntensity + Mathf.PingPong(Time.time * pulseSpeed, maxIntensity - minIntensity);

        // Apply the color multiplied by the intensity to the Emission property
        circuitMat.SetColor("_EmissionColor", pulseColor * emission);
    }
}