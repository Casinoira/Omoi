using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapController_backup : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Draggable> draggableObjects;
    public float snapRange = 0.5f;
    private Dictionary<Draggable, Vector3> initialPositions = new Dictionary<Draggable, Vector3>();
    

    void Start()
    {
        foreach(Draggable draggable in draggableObjects) {
            initialPositions.Add(draggable, draggable.transform.position);
            draggable.dragEndedCallback = OnDragEnded;
        }
        
    }

    private void OnDragEnded(Draggable draggable) {
        float closestDistance = Mathf.Infinity;
        Transform closestSnapPoint = null;
        Vector3 lastSnappedPosition = initialPositions[draggable];
        // int index = draggableObjects.IndexOf(draggable);
            
        foreach(Transform snapPoint in snapPoints) {

            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            
            if (currentDistance < closestDistance && currentDistance <= snapRange) {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;

            }
        }

            if (closestSnapPoint != null) {
                draggable.transform.localPosition = closestSnapPoint.localPosition;
                initialPositions[draggable] = closestSnapPoint.position;
                print("Snapped!");

            } else {
                draggable.transform.position = lastSnappedPosition;
                // draggable.transform.position = initialPositions[index];
                print("Not Snapped");
            }

    }

}
