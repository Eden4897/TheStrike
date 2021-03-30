using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public DashState dashState;
    public float dashTimer;
    public float maxDash = 3f;
    public float forceAmount = 10;

    public Rigidbody2D rb2d;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        switch (dashState)
        {
            case DashState.Ready:
                var isDashKeyDown = Input.GetMouseButtonDown(0);
                if (isDashKeyDown)
                {
                    //Get the position of this object in screen-coordinates
                    Vector3 posInScreen = Camera.main.WorldToScreenPoint(transform.position);

                    //You can calculate the direction from point A to point B using Vector3 dirAtoB = B - A;
                    Vector3 dirToMouse = Input.mousePosition - posInScreen;

                    //We normalize the direction (= make length of 1). This is to avoid the object moving with greater force when I click further away
                    dirToMouse.Normalize();

                    //Adding the force to the 2D Rigidbody, multiplied by forceAmount, which can be set in the Inspector
                    rb2d.velocity = dirToMouse * forceAmount;

                    dashState = DashState.Dashing;

                }
                break;

            case DashState.Dashing:
                dashTimer += Time.deltaTime * 3;
                animator.SetBool("Dash", true);
                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    dashState = DashState.Cooldown;
                }
                break;

            case DashState.Cooldown:
                dashTimer -= Time.deltaTime;
                
                if (dashTimer <= 3)
                {
                    animator.SetBool("Dash", false);
                }

                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                }
                break;
        }
        
    }
}
public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}