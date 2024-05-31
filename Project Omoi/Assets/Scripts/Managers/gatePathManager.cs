using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatePathManager : MonoBehaviour
{
    public Transform pivotPoint;
    public int rotationSpeed = 100;
    public float maxRotationAngle = 30.0f, pauseTime = 3f;

    private bool rotatingRight = true;

    void Start()
    {
        StartCoroutine(RotateGate());
    }

    IEnumerator RotateGate()
    {
        while (true)
        {
            float targetAngle = rotatingRight ? maxRotationAngle : -maxRotationAngle;
            Quaternion startRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle) * startRotation;

            float angleMoved = 0;
            while (angleMoved < Mathf.Abs(maxRotationAngle))
            {
                float angle = rotationSpeed * Time.deltaTime;
                transform.RotateAround(pivotPoint.position, Vector3.forward, angle * (rotatingRight ? 1 : -1));
                angleMoved += angle;
                yield return null;
            }

            yield return new WaitForSeconds(pauseTime);

            rotatingRight = !rotatingRight;
        }
    }
}