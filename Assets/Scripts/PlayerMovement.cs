using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 2;
    private float horizontalMovement;
    private bool isJumping = false;
    private bool canJump = true;
    private bool isGrounded = false;
    private Rigidbody2D rb;
    private float jumpTime = 0.5f;
    private float canJumpTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;
        isJumping = Input.GetButton("Jump");

        HandleJumpTime();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);

        Jump();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void Jump()
    {
        if (isJumping && canJump && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            canJump = false;
            canJumpTimer = jumpTime;
            isGrounded = false;
        }
    }

    private void HandleJumpTime()
    {
        if (canJump == false)
        {
            canJumpTimer -= Time.deltaTime;
        }
        if (canJumpTimer <= 0)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }
}
