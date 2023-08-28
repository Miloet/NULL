using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float SpinSpeed = 10;
    public float a = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(Mathf.Sin(Time.time* SpinSpeed)* a, Time.time* SpinSpeed, 0);
    }
}
