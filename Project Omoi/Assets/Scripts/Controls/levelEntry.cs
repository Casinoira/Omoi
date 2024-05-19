using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelEntry : MonoBehaviour
{
    public int sceneBuildIndex;
    public GameObject showButton;
    public SceneController sceneController;
 
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            showButton.SetActive(true);

        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            showButton.SetActive(false);

        }

    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player" && Input.GetKey(KeyCode.E)) {
            // SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            sceneController.LoadLevel(sceneBuildIndex);
        }

    }

}
