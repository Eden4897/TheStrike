using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float _xAxisDrag = 0.05f;
    private float _horizontalSpeed = 0;
    public float speed = 2f;
    public float jumpForce;
    public Transform groundDetector;
    public LayerMask groundLayers;
    public bool facingRight;
    public bool IsGrounded;

    public Animator animator;

    private void Update()
    {

        Collider2D groundCheck = Physics2D.OverlapCircle(groundDetector.position, 0.1f, groundLayers);

        if (groundCheck != null)
        {
            IsGrounded = true;
            animator.SetBool("Jump", false);
        }
        else if (groundCheck == null)
        {
            IsGrounded = false;
            animator.SetBool("Jump", true);
        }

        _horizontalSpeed = Input.GetAxisRaw("Horizontal");

        Flip();

        if (IsGrounded == true && Input.GetButtonDown("Jump"))
        {
            Jump();
        }


        animator.SetFloat("yVelocity", rb2d.velocity.y);
        animator.SetFloat("xVelocity", rb2d.velocity.x);

    }

    private void FixedUpdate()
    {

        animator.SetFloat("Speed", Mathf.Abs(_horizontalSpeed));

        rb2d.AddForce(new Vector2(_horizontalSpeed * speed, 0), ForceMode2D.Impulse);

        Vector3 velocity = rb2d.velocity;
        velocity.x = velocity.x / (_xAxisDrag + 1f);
        rb2d.velocity = velocity;

    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb2d.velocity.x, jumpForce);

        rb2d.velocity = movement;
    }

    void Flip()
    {
        if ((_horizontalSpeed < 0 && facingRight) || (_horizontalSpeed > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}