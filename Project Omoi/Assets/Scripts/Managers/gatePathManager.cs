using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatePathManager : MonoBehaviour
{
    [SerializeField] float lockedAngle1 = 0; 
    [SerializeField] float lockedAngle2 = -58;
    [SerializeField] int rotationSpeed = 30;

    Vector3 currentEulerAngles;
    public Transform pivotPoint;

    // Update is called once per frame
    void Update()
    {
        if (pivotPoint.eulerAngles.z <= lockedAngle1 ) {
            currentEulerAngles -= new Vector3(0,0, 2) * Time.deltaTime * rotationSpeed;
            pivotPoint.localEulerAngles = currentEulerAngles;

            if (pivotPoint.eulerAngles.z == lockedAngle2) {
                        currentEulerAngles += new Vector3(0,0, 2) * Time.deltaTime * rotationSpeed;
                        pivotPoint.localEulerAngles = currentEulerAngles;
            }
        }
    }
}
