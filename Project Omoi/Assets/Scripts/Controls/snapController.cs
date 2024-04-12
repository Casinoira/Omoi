using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Draggable> draggableObjects;
    public float snapRange = 0.5f;

    void Start()
    {
        foreach(Draggable draggable in draggableObjects) {
            draggable.dragEndedCallback = OnDragEnded;
        }
        
    }

    private void OnDragEnded(Draggable draggable) {
        float closestDistance = -1;
        Transform closestSnapPoint = null;
        // Vector3 currentSnapPoint = draggable.transform.localPosition;
            
        foreach(Transform snapPoint in snapPoints) {

            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            
            if (closestSnapPoint == null || currentDistance < closestDistance) {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;

            }

            if (closestSnapPoint != null && closestDistance <= snapRange) {
                draggable.transform.localPosition = closestSnapPoint.localPosition;
                // print("Snapped!");

            } else {
                // draggable.transform.localPosition = currentSnapPoint;
                // print("Not Snapped");
            }

            // currentSnapPoint = snapPoint.localPosition;
            // print("Snapped to" + snapPoint.localPosition);
        }
    }

}
