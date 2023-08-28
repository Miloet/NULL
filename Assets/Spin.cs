using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float SpinSpeed;
    public float WobbleSpeed;
    public float WobbleFrequency;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = Mathf.Repeat(time + Time.deltaTime* SpinSpeed, 360);
        transform.rotation = Quaternion.Euler(Mathf.Sin(time)* WobbleFrequency, time, 0);
    }
}
