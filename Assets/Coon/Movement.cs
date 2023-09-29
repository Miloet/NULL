using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float stamina;

    Rigidbody rb;
    Transform foot;
    bool grounded;

    Buffer jump;
    public float jumpSpeed = 10;
    public float jumpHeight = 0.6f;
    float jumping;
    float speedAtJump;

    public float leapSpeed = 10;
    Buffer leap;
    public bool leapt;
    float change;
    float movement;
    public float walkSpeed = 5;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        jump = Buffer.SetBuffer(gameObject,0.2f,false);
        leap = Buffer.SetBuffer(gameObject,0.1f,true);

        foot = GameObject.Find("Foot").transform;

        rb = GetComponent<Rigidbody>();

        stamina = 1;

        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = checkGround();

        if(grounded) leapt = false;

        Vector2 mouse = Input.mousePosition;
        Vector2 worldPos = cam.ScreenToWorldPoint(mouse);


        if (Input.GetAxisRaw("Jump") != 0) jump.Pressed();
        else jump.Unpress();
        if (Input.GetButtonDown("Leap")) leap.Pressed();
        movement = Input.GetAxis("Move");

        if (Input.GetAxisRaw("Sprint") != 0 && stamina != 0)
        {
            walkSpeed = 10;
            changeStamina(Time.deltaTime/2);
        }
        else walkSpeed = 5;

        if(leap.GetPress() && !leapt && stamina >= 0.3f)
        {
            rb.velocity = (worldPos - (Vector2)transform.position).normalized * leapSpeed;

            changeStamina(0.3f);
            leapt = true;
        }

        if (!leapt)
        {
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
        }

        if (change > 0) change -= Time.deltaTime;
        else stamina = Mathf.Min(stamina + Time.deltaTime/5, 1);
    }

    public void changeStamina(float c)
    {
        stamina -= c;
        stamina = Mathf.Clamp(stamina, 0, 1);
        change = 1;
        if (stamina == 0) change = 3;
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
