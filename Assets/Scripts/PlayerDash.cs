using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    public float forceAmount = 10;

    public Rigidbody2D rb2d;

    // Update is called once per frame
    void Update()
    {
        //If left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            //Get the position of this object in screen-coordinates
            Vector3 posInScreen = Camera.main.WorldToScreenPoint(transform.position);

            //You can calculate the direction from point A to point B using Vector3 dirAtoB = B - A;
            Vector3 dirToMouse = Input.mousePosition - posInScreen;

            //We normalize the direction (= make length of 1). This is to avoid the object moving with greater force when I click further away
            dirToMouse.Normalize();

            //Adding the force to the 2D Rigidbody, multiplied by forceAmount, which can be set in the Inspector
            rb2d.velocity = dirToMouse * forceAmount;
        }
    }
}
