using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipEventManager : MonoBehaviour
{
    public void SkipCutscene() {
        switch (GameManager.Instance.State) {
            case GameManager.GameState.EndGame:
                SceneManager.LoadScene("Credits");
                break;
            default:
                SceneManager.LoadScene("World");
                break;
        }
    }

    // public void SkipDialogue() {

    // }
}
