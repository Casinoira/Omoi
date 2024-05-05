using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftFlipperControl : MonoBehaviour
{
    public float speed = 0f;
    private HingeJoint2D hingeJoint2D;
    private JointMotor2D jointMotor;
    private Rigidbody2D myLeftFlipper;

    public Collider2D flipperCollider, IgnoredCollider;

    void Start() {
        hingeJoint2D = GetComponent<HingeJoint2D>();
        jointMotor = hingeJoint2D.motor;
        
        Physics2D.IgnoreCollision(flipperCollider, IgnoredCollider, true);
    }
    void FixedUpdate()
    {
        myLeftFlipper = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.A)){
            jointMotor.motorSpeed = speed;
            hingeJoint2D.motor = jointMotor;

        } else {
            jointMotor.motorSpeed = -speed;
            hingeJoint2D.motor = jointMotor;
        }   
    }
}
