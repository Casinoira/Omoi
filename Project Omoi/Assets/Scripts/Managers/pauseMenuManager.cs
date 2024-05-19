using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenuManager : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;

    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home() {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1;
    }

        public void NewGame() {
        SceneManager.LoadScene("World");
        Time.timeScale = 1;
    }

    public void Level1() {
        SceneManager.LoadScene("Level_01");
        Time.timeScale = 1;
    }

    public void Level2() {
        SceneManager.LoadScene("Level_02");
        Time.timeScale = 1;
    }
    
    public void Level3() {
        SceneManager.LoadScene("Level_03");
        Time.timeScale = 1;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void LeaveLevel() {
        SceneManager.LoadScene("World");
    }

    public void Exit() {
        Application.Quit();
    }
}
