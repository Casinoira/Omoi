using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballControl : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.gameObject.name == "Drop_Collider") {
            // GameManager.Instance.UpdateGameState(GameState.GameOver);
            // RestartScene();
        //     Debug.Log("Game Over");
        // }
    }
    
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
