using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stairs : MonoBehaviour
{
    public GameObject teleport;
    public static TextMeshProUGUI text;
    public static bool a;
    bool entered = false;

    private void Start()
    {
        if (text == null) text = GameObject.Find("Action").GetComponent<TextMeshProUGUI>();

        text.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Coon")
        {
            entered = true;
            text.text = "Use Stairs: E";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Coon")
        {
            entered = false;
            text.text = "";
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(entered && Input.GetKeyDown(KeyCode.E))
        {
            Movement.self.position = new Vector3(teleport.transform.position.x, teleport.transform.position.y + 0.25f, Movement.self.position.z);
        }
    }
}
