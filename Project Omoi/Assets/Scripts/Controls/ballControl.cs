using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballControl : MonoBehaviour {
    public AudioSource audioHit;
    public AudioSource audioSpeed;

    private void OnCollisionEnter2D(Collision2D ball_Col) {
        if (ball_Col.gameObject.tag != "PinballFrame") {

            if (ball_Col.gameObject.name == "Road_Surface") {
                audioSpeed.Play();

            } else {
                audioHit.Play();

            }

        }

    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
        // if (collision.gameObject.name == "Drop_Collider") {
            // GameManager.Instance.UpdateGameState(GameState.GameOver);
            // RestartScene();
        //     Debug.Log("Game Over");
        // }
    // }
    
    // public void RestartScene()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }


}
