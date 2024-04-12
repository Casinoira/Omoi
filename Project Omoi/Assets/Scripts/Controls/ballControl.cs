using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballControl : MonoBehaviour {
    public AudioSource audioHit;
    public AudioSource audioSpeed;
    public AudioSource audioMemoryHit;

    private void OnCollisionEnter2D(Collision2D ball_Col) {
        if (ball_Col.gameObject.tag == "Draggable" || ball_Col.gameObject.tag == "Multiplier" || ball_Col.gameObject.tag == "Undraggable" ) {
            audioHit.Play();

        } else if (ball_Col.gameObject.name == "Memory_Ball") {
            audioMemoryHit.Play();
            
        }

    }
    void OnTriggerEnter2D(Collider2D ball_Col) {
        if (ball_Col.gameObject.name == "Detect_SpeedPass") {
            audioSpeed.Play();

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
