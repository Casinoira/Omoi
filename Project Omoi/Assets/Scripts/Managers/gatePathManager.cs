using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatePathManager : MonoBehaviour
{
    [SerializeField] float lockedAngle1 = 0; 
    [SerializeField] float lockedAngle2 = -58;
    [SerializeField] int rotationSpeed = 100;

    Vector3 currentEulerAngles;
    public Transform pivotPoint;
    // private bool isRotateLeft = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        currentEulerAngles += new Vector3(0,0, 2) * Time.deltaTime * rotationSpeed;
        pivotPoint.localEulerAngles = currentEulerAngles;

        // if (isRotateLeft) {
        //     currentEulerAngles += new Vector3(0,0, 2) * Time.deltaTime * rotationSpeed;
        //     pivotPoint.localEulerAngles = currentEulerAngles;

        //     if (pivotPoint.eulerAngles.z == lockedAngle1) {
        //         isRotateLeft = false;
        //     }
        // } else if (!isRotateLeft) {
        //     currentEulerAngles -= new Vector3(0,0, 2) * Time.deltaTime * rotationSpeed;
        //     pivotPoint.localEulerAngles = currentEulerAngles;

        //     if (pivotPoint.eulerAngles.z == lockedAngle2) {
        //         isRotateLeft = true;
        //     }
        // }
    }

    private void LimitRotation() {
        // pivotPoint.rotation.eulerAngles.z = Mathf.Clamp(pivotPoint.rotation.eulerAngles.z , lockedAngle2, lockedAngle1);


    }
}
