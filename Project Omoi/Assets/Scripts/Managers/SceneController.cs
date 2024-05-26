using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    // public GameManager gameManager;
    public Animator transition;
    public float transitionTime = 1f;

    public GameObject memoryBall, Tower1, Tower2;
    public VideoPlayer videoPlayer;

    private string activeSceneName;
    private Animator TowerAnim1, TowerAnim2;
    private AudioSource TowerAudio1, TowerAudio2;
    private BoxCollider2D Tower1Box, Tower2Box;

    void Awake()
    {
        activeSceneName = SceneManager.GetActiveScene().name;
        if (activeSceneName == "World") {
            GameManager.Instance.MovePlayerToSavedPosition();

            TowerAnim1 = Tower1.GetComponent<Animator>();
            TowerAnim2 = Tower2.GetComponent<Animator>();

            TowerAudio1 = Tower1.GetComponent<AudioSource>();
            TowerAudio2 = Tower2.GetComponent<AudioSource>();

            Tower1Box = Tower1.GetComponent<BoxCollider2D>();
            Tower2Box = Tower2.GetComponent<BoxCollider2D>();

            switch (GameManager.Instance.State) {
                case GameManager.GameState.Level01:
                    // Handle Level 01 state
                    break;

                case GameManager.GameState.Level02:
                    TowerAnim1.SetTrigger("SceneChange");
                    TowerAudio1.Play();
                    Tower1Box.enabled = false;
                    break;

                case GameManager.GameState.Level03:
                    TowerAnim2.SetTrigger("SceneChange");
                    TowerAudio2.Play();
                    Tower2Box.enabled = false;
                    break;

                case GameManager.GameState.EndGame:
                    // Handle EndGame state
                    break;

                default:
                    break;
            }
        }

        if (videoPlayer != null) {
            Debug.Log("Starting video playback...");
            videoPlayer.Play();
            StartCoroutine(WaitForVideoToEndAndLoadWorld());
            // LoadWorldLevel();
        }

    }

    void Update() {     
        if (activeSceneName == "Level_01" || activeSceneName == "Level_02" || activeSceneName == "Level_03") {
            if (memoryBall == null || memoryBall.Equals(null) || !memoryBall.activeSelf) {
                LoadCutsceneLevel();
            }
        }
        
    }

    public void LoadLevel(int levelIndex){
        StartCoroutine(LoadPinballLevel(levelIndex));
    }

    public void LoadCutsceneLevel() {
        StartCoroutine(LoadCutscene());
    }

    IEnumerator LoadPinballLevel(int levelIndex) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        string activeSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(levelIndex);

    }

    IEnumerator LoadCutscene() {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        switch (activeSceneName) {
            case "Level_01":
                SceneManager.LoadScene("Lvl_01_Cutscene");
                break;

            case "Level_02":
                SceneManager.LoadScene("Lvl_02_Cutscene");
                break;

            case "Level_03":
                SceneManager.LoadScene("Lvl_03_Cutscene");
                break;

            default:
                break;

        }
    }

    IEnumerator WaitForVideoToEndAndLoadWorld()
    {
        switch (activeSceneName) {
            case "Lvl_01_Cutscene":
                yield return new WaitForSeconds(33f);
                GameManager.Instance.UpdateGameState(GameManager.GameState.Level02);
                break;

            case "Lvl_02_Cutscene":
                yield return new WaitForSeconds(50f);
                GameManager.Instance.UpdateGameState(GameManager.GameState.Level03);
                break;

            case "Lvl_03_Cutscene":
                yield return new WaitForSeconds(51f);
                GameManager.Instance.UpdateGameState(GameManager.GameState.EndGame);
                break;

            default:
                break;

        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        switch (GameManager.Instance.State) {
            case GameManager.GameState.EndGame:
                SceneManager.LoadScene("Credits");
                break;
            default:
                SceneManager.LoadScene("World");
                break;
        }
    }
}
