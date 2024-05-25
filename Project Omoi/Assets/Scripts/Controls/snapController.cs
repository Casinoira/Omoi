using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Draggable> draggableObjects;
    public float snapRange = 0.5f;
    public Collider2D trayCollider; // Reference to the tray collider
    private Dictionary<Draggable, Vector3> initialPositions = new Dictionary<Draggable, Vector3>();
    private Dictionary<Transform, Draggable> snappedObjects = new Dictionary<Transform, Draggable>();

    void Start()
    {
        foreach (Transform snapPoint in snapPoints)
        {
            snappedObjects.Add(snapPoint, null);
        }

        foreach (Draggable draggable in draggableObjects)
        {
            initialPositions.Add(draggable, draggable.transform.position);
            draggable.dragEndedCallback = OnDragEnded;

            foreach (Transform snapPoint in snapPoints)
            {
                if (Vector3.Distance(draggable.transform.position, snapPoint.position) < snapRange)
                {
                    snappedObjects[snapPoint] = draggable;
                    break;
                }
            }
        }
    }
    private void OnDragEnded(Draggable draggable)
    {
        bool isInTray = IsInTray(draggable);
        
        if (isInTray)
        {
            // If the draggable is in the tray, place it at the release point within the tray
            Vector3 releasePoint = draggable.transform.position;
            releasePoint.x = Mathf.Clamp(releasePoint.x, trayCollider.bounds.min.x, trayCollider.bounds.max.x);
            releasePoint.y = Mathf.Clamp(releasePoint.y, trayCollider.bounds.min.y, trayCollider.bounds.max.y);
            releasePoint.z = 0f; // Assuming the tray is in 2D space

            draggable.transform.position = releasePoint;
            Debug.Log("Placed in tray at " + releasePoint);
        }
        else
        {
            // If the draggable is not in the tray, proceed with snapping logic
            float closestDistance = Mathf.Infinity;
            Transform closestSnapPoint = null;
            Vector3 lastSnappedPosition = initialPositions[draggable];

            foreach (Transform snapPoint in snapPoints)
            {
                float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);

                if (currentDistance < closestDistance && currentDistance <= snapRange && (snappedObjects[snapPoint] == null || snappedObjects[snapPoint] == draggable))
                {
                    closestSnapPoint = snapPoint;
                    closestDistance = currentDistance;
                }
            }

            if (closestSnapPoint != null)
            {
                ReleaseSnapPoint(draggable);
                draggable.transform.localPosition = closestSnapPoint.localPosition;
                initialPositions[draggable] = closestSnapPoint.position;
                snappedObjects[closestSnapPoint] = draggable;
                Debug.Log("Snapped!");
            }
            else
            {
                draggable.transform.position = lastSnappedPosition;
                Debug.Log("Not Snapped");
            }
        }
    }

    private bool IsInTray(Draggable draggable)
    {
        return trayCollider.OverlapPoint(draggable.transform.position);
    }

    private void ReleaseSnapPoint(Draggable draggable)
    {
        List<Transform> keysToRemove = new List<Transform>();

        foreach (var pair in snappedObjects)
        {
            if (pair.Value == draggable)
            {
                keysToRemove.Add(pair.Key);
            }
        }

        foreach (var key in keysToRemove)
        {
            snappedObjects[key] = null;
        }
    }
}
