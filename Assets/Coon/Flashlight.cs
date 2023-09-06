using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Camera cam;
    public Transform test;
    Plane plane = new Plane(Vector3.forward, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure the mouse is at the same depth as the object

        test.transform.position = mousePosition;

        // Calculate the angle between the object and the mouse
        float angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;

        // Create a rotation based on the calculated angle
        Quaternion rotation = Quaternion.Euler(new Vector3(-angle, 90, 0));

        // Apply the rotation to the object
        transform.rotation = rotation;
    }
}
