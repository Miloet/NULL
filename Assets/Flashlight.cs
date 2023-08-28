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
        Vector2 worldPosition = Vector2.zero;
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }

        test.position = worldPosition;

        Vector2 direction = ((Vector2)worldPosition - (Vector2)transform.position).normalized;

        //create the rotation we need to be in to look at the target
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        Quaternion angle = lookRotation;//Quaternion.Slerp(transform.rotation, lookRotation, 1);

        //rotate us over time according to speed until we are in the required rotation
        transform.rotation = angle;
    }
}
