using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float jumpForce, jumpCD, jump, xforce;

    private bool jumpside = true;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        jump = jump - Time.deltaTime;
        if (rb.velocity.y == 0)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            jump = jumpCD;
        }
        if (jump < 0 && rb.velocity.y == 0)
        {
            if (jumpside)
            {
                jumpside = false;
                JumpRigth();

            }
            else
            {
                jumpside = true;
                JumpLeft();

            }
            jump = jumpCD;
        }
    }

    private void JumpLeft()
    {
        rb.AddForce(new Vector2(-xforce, jumpForce));
    }

    private void JumpRigth()
    {
        rb.AddForce(new Vector2(xforce, jumpForce));
    }
}
