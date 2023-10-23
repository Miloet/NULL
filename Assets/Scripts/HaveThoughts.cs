using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveThoughts : MonoBehaviour
{
    public bool repeating;
    public string text;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Coon")
        {
            Thoughts.setText(text);
            if (!repeating) Destroy(gameObject);
        }
    }
}
