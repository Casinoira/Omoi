using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapControllerBackup : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Draggable> draggableObjects;
    public float snapRange = 0.5f;
    private Dictionary<Draggable, Vector3> initialPositions = new Dictionary<Draggable, Vector3>();
    private Dictionary<Transform, Draggable> snappedObjects = new Dictionary<Transform, Draggable>();

    void Start()
    {
        foreach (Transform snapPoint in snapPoints) {
            snappedObjects.Add(snapPoint, null);

        }

        foreach(Draggable draggable in draggableObjects) {
            initialPositions.Add(draggable, draggable.transform.position);
            draggable.dragEndedCallback = OnDragEnded;

            foreach (Transform snapPoint in snapPoints) {
                if (Vector3.Distance(draggable.transform.position, snapPoint.position) < snapRange) {
                    snappedObjects[snapPoint] = draggable;
                    break;
                }
            }
        }

    }

    private void OnDragEnded(Draggable draggable) {
        float closestDistance = Mathf.Infinity;
        Transform closestSnapPoint = null;
        Vector3 lastSnappedPosition = initialPositions[draggable];
        // int index = draggableObjects.IndexOf(draggable);
            
        foreach(Transform snapPoint in snapPoints) {

            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            
            if (currentDistance < closestDistance && currentDistance <= snapRange && snappedObjects[snapPoint] == null) {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;

            }
        }

            if (closestSnapPoint != null) {
                ReleaseSnapPoint(draggable);
                
                draggable.transform.localPosition = closestSnapPoint.localPosition;
                initialPositions[draggable] = closestSnapPoint.position;
                snappedObjects[closestSnapPoint] = draggable;
                print("Snapped!");

            } else {
                draggable.transform.position = lastSnappedPosition;
                // draggable.transform.position = initialPositions[index];
                print("Not Snapped");
            }

    }

    private void ReleaseSnapPoint(Draggable draggable)
    {
        foreach (var pair in snappedObjects)
        {
            if (pair.Value == draggable)
            {
                snappedObjects[pair.Key] = null;
                break;
            }
        }
    }
}
