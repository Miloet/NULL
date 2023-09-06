using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternScript : MonoBehaviour
{

    public Gradient color;
    public Gradient lightColor;
    Light light;
    Material lightMat;
    float baseIntensity; 
    public float xScale = 1.0f;

    private void Start()
    {
        lightMat = transform.Find("Lantern/Light").GetComponent<Renderer>().material;
        light = transform.Find("Point Light").GetComponent<Light>();
        baseIntensity = light.intensity;
    }

    void Update()
    {
        float height = Mathf.PerlinNoise1D(Time.time * xScale);
        lightMat.SetColor("_EmissionColor", color.Evaluate(height));
        lightMat.color = color.Evaluate(height);
        light.intensity = baseIntensity * (1 + height/2);
        light.color = lightColor.Evaluate(height);
    }
}
