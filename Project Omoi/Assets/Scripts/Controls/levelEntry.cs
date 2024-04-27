using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelEntry : MonoBehaviour
{
    public int sceneBuildIndex;
    public GameObject showControl;

    private void OnTriggerEnter2D(Collider2D other) {
        print("Door Acitvate");
        if (other.tag == "Player") {
            showControl.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player" && Input.GetKey(KeyCode.E)) {
            print("Player entering");
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            showControl.SetActive(false);
        }
    }
}
