using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightFlipperControl : MonoBehaviour
{
    public float speed = 0f;
    private HingeJoint2D hingeJoint2D;
    private JointMotor2D jointMotor;
    private Rigidbody2D myRightFlipper;

    void Start() {
        hingeJoint2D = GetComponent<HingeJoint2D>();
        jointMotor = hingeJoint2D.motor;
    }
    
    void FixedUpdate()
    {
        myRightFlipper = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.D)){
            jointMotor.motorSpeed = -speed;
            hingeJoint2D.motor = jointMotor;
        } else {
            jointMotor.motorSpeed = speed;
            hingeJoint2D.motor = jointMotor;
        }   
    }
}
