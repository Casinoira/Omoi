using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatePathManager : MonoBehaviour
{
    // Vector3 currentEulerAngles;

    public Transform pivotPoint;
    public int rotationSpeed = 100;
    public float maxRotationAngle = 58.0f, pauseTime = 3f;

    private bool rotatingRight = true;
    private float timer = 0f;


    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= pauseTime) {
            rotatingRight = !rotatingRight;
            timer = 0.0f;
        }

        if (rotatingRight) {
            RotateRight();
        }else {
            RotateLeft();
        }
        // currentEulerAngles += new Vector3(0,0, 2) * Time.deltaTime * rotationSpeed;
        // pivotPoint.localEulerAngles = currentEulerAngles;
    }

    private void RotateRight() {
        transform.RotateAround(pivotPoint.position, Vector3.forward, rotationSpeed * Time.deltaTime);

        ClampRotation();
    }

    private void RotateLeft() {
        transform.RotateAround(pivotPoint.position, Vector3.back, rotationSpeed * Time.deltaTime);

        ClampRotation();
    }

    private void ClampRotation()
    {
        float currentRotation = pivotPoint.eulerAngles.z;

        if (currentRotation > 180.0f)
        {
            currentRotation -= 360.0f;
        }

        float clampedRotation = Mathf.Clamp(currentRotation, -maxRotationAngle, maxRotationAngle);

        // transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, clampedRotation);
    }
}
