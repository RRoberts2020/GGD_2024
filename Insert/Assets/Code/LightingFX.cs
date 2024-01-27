using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingFX : MonoBehaviour
{
    public float colorChangeSpeed = 1.0f; // Adjust the speed of color change

    private Light directionalLight;
    private float hueValue = 0.0f;

    void Start()
    {
        directionalLight = GetComponent<Light>();
    }

    void Update()
    {
        // Update the hue value based on time and speed
        hueValue = (hueValue + colorChangeSpeed * Time.deltaTime) % 1.0f;

        // Set the light color based on the current hue value
        directionalLight.color = Color.HSVToRGB(hueValue, 1.0f, 1.0f);
    }
}
