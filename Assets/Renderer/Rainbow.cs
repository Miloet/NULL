using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Rainbow : MonoBehaviour
{

    Material m;
    public Vector3 g;
    // Start is called before the first frame update
    void Start()
    {
        m = GetComponent<Image>().material;
    }

    // Update is called once per frame
    void Update()
    {
        g = new Vector3(sin(0.8f), sin(1.2f), sin(1));

        m.SetVector("_Color", new Vector3(16f * g.x, 16f * g.y, 16f * g.z));
    }
    public static float sin(float x)
    {
        return Mathf.Pow(Mathf.Sin(x * Time.time),2);
    }
}
