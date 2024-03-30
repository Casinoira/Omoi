using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftFlipperControl : MonoBehaviour
{
    public float speed = 0f;
    private Rigidbody2D myLeftFlipper;

    // Update is called once per frame
    void Update()
    {
        myLeftFlipper = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.A)){
            myLeftFlipper.AddTorque(speed);

        } else {
            myLeftFlipper.AddTorque(-speed);

        }   
    }
}
