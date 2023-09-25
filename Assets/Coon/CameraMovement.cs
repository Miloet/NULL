using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform raccoon;
    Rigidbody speed;
    public float rotationSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        raccoon = GameObject.Find("Coon").transform;
        speed = raccoon.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion target = Quaternion.Euler(5 - speed.velocity.y*2, speed.velocity.x*2, 0);

        transform.rotation = Quaternion.Lerp(transform.rotation, target, rotationSpeed);
        transform.position = raccoon.position + new Vector3(0, 1);
    }
}
