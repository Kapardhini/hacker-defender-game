using UnityEngine;
public class NeonPulse : MonoBehaviour
{
    [Header("Glow Settings")]
    public Color neonColor = Color.cyan;
    public float minBrightness = 1.0f;
    public float maxBrightness = 3.0f;
    public float pulseSpeed = 2.0f;
    private Material objectMaterial;
    void Start()
    {
        // Get the material from the object's Renderer component
        objectMaterial = GetComponent<Renderer>().material;
        // Ensure the material has Emission enabled so it can glow
        objectMaterial.EnableKeyword("_EMISSION");
    }
    void Update()
    {
        // Calculate the pulse using a Sine wave for smooth looping
        // (Sin varies from -1 to 1, we map it to 0 to 1)
        float pulse = (Mathf.Sin(Time.time * pulseSpeed) + 1.0f) / 2.0f;
        // Interpolate between min and max brightness based on the pulse
        float intensity = Mathf.Lerp(minBrightness, maxBrightness, pulse);
        // Apply the color and intensity to the material's Emission property
        // The unique magic here is multiplying color by intensity (HDR)
        objectMaterial.SetColor("_EmissionColor", neonColor * intensity);
    }
}