using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public void NewGame() {
        GameManager.Instance.LoadNewGame();
        SceneManager.LoadScene("World");
        Time.timeScale = 1;
    }

    public void CreditScreen() {
        SceneManager.LoadScene("Credits");
        Time.timeScale = 1;
    }

    public void GuideScreen() {
        SceneManager.LoadScene("Guide");
        Time.timeScale = 1;
    }

    public void Home() {
        SceneManager.LoadScene("StartScreen");
        GameManager.Instance.UpdateGameState(GameManager.GameState.NewGame);
        Debug.Log("GO HOME");
        Time.timeScale = 1;
    }
    
    public void Exit() {
        Application.Quit();
    }
}
