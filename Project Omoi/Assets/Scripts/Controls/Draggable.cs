using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public delegate void DragEndedDelegate(Draggable draggableObject);

    public DragEndedDelegate dragEndedCallback;
    
    private bool isDragging = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;

    private Collider2D collider2D;

    private void Start() {
        collider2D = GetComponent<Collider2D>();
    }
    
    public void OnMouseDown() {
        isDragging = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;

        collider2D.enabled = false;

    }

    public void OnMouseUp() {
        isDragging = false;
        dragEndedCallback(this);
        collider2D.enabled = true;

    }

    void OnMouseDrag() {
        if(isDragging) {
            transform.localPosition = spriteDragStartPosition + Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition;

        }
    }

    void OnMouseOver() {
        
        if (!isDragging) {
            if (Input.GetMouseButtonDown(1)) {
                transform.Rotate(0f,0f,-45f);

                print(transform.rotation);
            } 
        }
    }
}
