using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Transform cam;
    public float speed = 10;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        if (Input.GetAxisRaw("Vertical") != 0)
            Jump();

        cam.position = transform.position;
        cam.rotation = Quaternion.Euler(-rb.velocity.y, rb.velocity.x, 0);
    }


    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 10);
    }
}
