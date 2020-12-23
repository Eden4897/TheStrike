using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    private float _horizontalSpeed = 0;
    private float _speed = 2f;
    private bool _isJump = false;
    private int _maxJumps = 2;
    public int _jumps = 2;
    private void Start()
    {
        
    }

    private void Update()
    {
        _horizontalSpeed = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            _isJump = true;
        }
    }

    private void FixedUpdate()
    {
        rb2d.AddForce(new Vector2(_horizontalSpeed * _speed, 0), ForceMode2D.Impulse);
        if (_isJump && _jumps != 0)
        {
            rb2d.AddForce(new Vector2(0, 50), ForceMode2D.Impulse);
            _isJump = false;
            _jumps--;
        }
    }

    public void ResetJumps()
    {
        _jumps = _maxJumps;
    }
}
