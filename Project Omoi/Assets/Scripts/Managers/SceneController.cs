using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public GameObject memoryBall;

    void Update() {
        if (SceneManager.GetActiveScene().name != "World") {
            if (memoryBall == null || !memoryBall.activeSelf) {
                LoadLevel(1);
            }
        }

    }

    public void LoadLevel(int levelIndex) {
        StartCoroutine(LoadCutscene(levelIndex));

    }

    IEnumerator LoadCutscene(int levelIndex) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        if (SceneManager.GetActiveScene().name != "World") {
            SceneManager.LoadScene("World");
        } else {
            SceneManager.LoadScene(levelIndex);
        }
    }
}
