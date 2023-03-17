using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float JumpSpeed;
    private Rigidbody2D rb;

    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask WhatIsGround;
    public bool isGrounded;

    //extra Jump
    public int maxJumpValue;
    int maxJump;



    private void Start()
    {
        maxJump = maxJumpValue;
        rb = GetComponent<Rigidbody2D>();




    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius,WhatIsGround);

        if (Input.GetMouseButtonDown(0) && maxJump > 0 || Input.GetKeyDown(KeyCode.Tab) && maxJump > 0)
        {
            maxJump--;
            Jump();
        }else if (Input.GetMouseButtonDown(0) && maxJump ==0 && isGrounded || Input.GetKeyDown(KeyCode.Tab) && maxJump == 0)
        {
            Jump(); 

        }
        if(isGrounded) {

            maxJump = maxJumpValue;
        }
        if(isGrounded == false)
        {
            FindObjectOfType<AudioManager>().Play("Land");
        }
    }

    void Jump()
    {
        FindObjectOfType<AudioManager>().Play("Jump");
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0,JumpSpeed));
    }
}
