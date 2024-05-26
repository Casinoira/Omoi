using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenuManager : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu, pauseButton;

    // public void LoadGame() {
    //     // gameManager.LoadGame();
    // }

    // public void SaveGame() {
    //     // gameManager.SaveGame();
    // }

    // public void Level1() {
    //     SceneManager.LoadScene("Level_01");
    //     Time.timeScale = 1;
    // }

    // public void Level2() {
    //     SceneManager.LoadScene("Level_02");
    //     Time.timeScale = 1;
    // }
    
    // public void Level3() {
    //     SceneManager.LoadScene("Level_03");
    //     Time.timeScale = 1;
    // }

    public void Home() {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1;
    }
    
    public void Pause() {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void LeaveLevel() {
        SceneManager.LoadScene("World");
    }

}
