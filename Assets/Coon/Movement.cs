using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public GameObject cube;
    Rigidbody rb;
    Transform foot;
    bool grounded;

    Buffer jump;
    public float jumpSpeed = 10;
    public float jumpHeight = 0.6f;
    float jumping;
    float speedAtJump;

    Buffer leap;
    public bool leapt;
    float movement;
    public float walkSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        jump = Buffer.SetBuffer(gameObject,0.2f,false);
        leap = Buffer.SetBuffer(gameObject, 0.2f, false);

        foot = GameObject.Find("Foot").transform;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = checkGround();

        if (Input.GetAxisRaw("Jump") != 0) jump.Pressed();
        else jump.Unpress();
        if (Input.GetAxisRaw("Leap") != 0) leap.Pressed();
        movement = Input.GetAxis("Move");

        //if(leap.Pressed() && !leapt)
        {

        }

        if (jump.GetPress() && grounded)
        { 
            jumping = jumpHeight;
            speedAtJump = rb.velocity.x;
        }

        if (jump.GetPress() && jumping > 0)
        {
            rb.velocity = new Vector2(speedAtJump, jumpSpeed);
            jumping -= Time.deltaTime;
        }
        else resetJumping();

        if (jumping <= 0)
            rb.velocity = new Vector2(movement * walkSpeed, rb.velocity.y);
        else rb.velocity = new Vector2(speedAtJump + (movement * walkSpeed)/4, rb.velocity.y);

        //cube.SetActive(grounded);
    }

    public bool checkGround()
    {
        LayerMask layer = LayerMask.GetMask("Ground", "Background");
        return Physics.Raycast(foot.position, Vector3.down, 0.1f, layer, QueryTriggerInteraction.Ignore);
    }

    public void resetJumping()
    {
        if (jumping > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            jumping = 0;
        }
    }
}
