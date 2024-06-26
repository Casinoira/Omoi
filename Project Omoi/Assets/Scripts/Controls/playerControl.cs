using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float acceleration, groundSpeed, jumpSpeed;

    [Range(0f, 1f)]
    public float groundDecay;
    public bool grounded;
    public Rigidbody2D body;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;

    float xInput;
    float yInput;

    void Start()
    {
        
    }

    void Update()
    {
        GetInput();
        Handlejump();
    }

    void FixedUpdate() {
        MoveWithInput();
        CheckGround();
        ApplyFriction();
    }

    void GetInput() {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

    }

    void MoveWithInput() {
        if (Mathf.Abs(xInput) > 0) {
            float increment = xInput * acceleration;
            float newSpeed = Mathf.Clamp(body.velocity.x + increment, -groundSpeed, groundSpeed);

            body.velocity = new Vector2(xInput * groundSpeed, body.velocity.y);

            float direction = Mathf.Sign(xInput);
            transform.localScale = new Vector3(direction, 1, 1);
        }

    }

    void Handlejump() {
        
        if (Input.GetButtonDown("Jump") && grounded) {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }
    }

    void CheckGround() {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }
    
    void ApplyFriction() {
        if (grounded && xInput == 0 && body.velocity.y < 0) {
            body.velocity *= groundDecay;
        }
    }
}
