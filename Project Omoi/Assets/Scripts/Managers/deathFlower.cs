using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathFlower : MonoBehaviour
{
    public float hoverDistance = 0.5f,  hoverSpeed = 1f; 
    public float bounceHeight = 0.2f, bounceFrequencyMultiplier = 2f;
    public bool isHorizontal = false;


    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float horizontalHoverValue = Mathf.Sin(Time.time * hoverSpeed) * hoverDistance;
        float verticalHoverValue = Mathf.Sin(Time.time * hoverSpeed * bounceFrequencyMultiplier) * bounceHeight;

        Vector2 newPosition;

        if (isHorizontal)
        {
             newPosition = new Vector2(startPos.x + horizontalHoverValue, startPos.y + verticalHoverValue);
        }
        else
        {
            newPosition = new Vector2(transform.position.x, startPos.y + horizontalHoverValue + verticalHoverValue);
        }

        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Player") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
