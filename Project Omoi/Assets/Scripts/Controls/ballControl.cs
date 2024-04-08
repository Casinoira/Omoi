using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballControl : MonoBehaviour
{
    // public static ballControl Instance;
    public Rigidbody2D ball;
    Vector2 move;
    [SerializeField] public float force;
    private float boostTimer;
    private bool isBoost = false;

    private void Start() {
        ball = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.gameObject.name == "Drop_Collider") {
            // GameManager.Instance.UpdateGameState(GameState.GameOver);
            // RestartScene();
        //     Debug.Log("Game Over");
        // }
    }

    void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.name == "SpeedBoost") {
            isBoost = true;
            print("isBoosted is " + isBoost);
            print("Move " + Vector3.forward);

            if (isBoost == true) {
                boostTimer = Time.deltaTime;

                ball.AddForce(move.up * force * Time.deltaTime);

                if(boostTimer >= 2) {
                    boostTimer = 0;
                    isBoost = false;
                }
            }
        }
    }
    
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
