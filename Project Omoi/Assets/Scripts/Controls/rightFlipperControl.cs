using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightFlipperControl : MonoBehaviour
{
    public float speed = 0f;
    private Rigidbody2D myRightFlipper;

    // Update is called once per frame
    void FixedUpdate()
    {
        myRightFlipper = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.D)){
            myRightFlipper.AddTorque(-speed);

        } else {
            myRightFlipper.AddTorque(speed);
            
        }   
    }
}
