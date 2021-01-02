using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movementSpeed;
    public float jumpForce;
    public Transform groundDetector;
    public LayerMask groundLayers;
    public bool facingRight;

    public Animator animator;

    float mx;

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");

        Flip();

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            animator.SetBool("Jump", true);
            Jump();
        }

        animator.SetFloat("yVelocity", rb.velocity.y);

    }

    private void FixedUpdate()
    {
        animator.SetFloat("Speed", Mathf.Abs(mx));

        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

        rb.velocity = movement;

    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movement;
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(groundDetector.position, 0.1f, groundLayers);

        if (groundCheck != null)
        {
            return true;
        }

        return false;
    }

    void Flip()
    {
        if ((mx < 0 && facingRight) || (mx > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}