using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingRock : MonoBehaviour
{
public float hoverHeight = 0.5f; 
    public float hoverSpeed = 1f;

    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;

        transform.position = new Vector2(transform.position.x, newY);
    }
}
