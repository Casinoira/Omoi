using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    public Animator transition;
    public float transitionTime = 1f;
    public GameObject memoryBall, Tower1, Tower2;
    public VideoPlayer videoPlayer;
    public DialogueTrigger dialogueTrigger;

    private string activeSceneName;
    private Animator TowerAnim1, TowerAnim2;
    private AudioSource TowerAudio1, TowerAudio2;
    private BoxCollider2D Tower1Box, Tower2Box;

    void Awake()
    {
        Debug.Log("I'm Awake Scene");
        activeSceneName = SceneManager.GetActiveScene().name;

        if (videoPlayer != null) {
            Debug.Log("Starting video playback...");
            videoPlayer.Play();
            StartCoroutine(WaitForVideoToEndAndLoadWorld());
            // LoadWorldLevel();
        }

    }

    void Start() {
        PlayDialogue();
        TowerOpen();
        if (activeSceneName == "World") {
            GameManager.Instance.MovePlayerToSavedPosition();
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

    public void PlayDialogue() {
        if (activeSceneName == "World") {
            switch (GameManager.Instance.State) {
                case GameManager.GameState.Level01:
                    // Debug.Log("Activate Dialogue Trigger");
                    dialogueTrigger.TriggerDialogue("Awakening");
                    break;
                case GameManager.GameState.Level02:
                    dialogueTrigger.TriggerDialogue("Memory1Complete");
                    break;
                case GameManager.GameState.Level03:
                    dialogueTrigger.TriggerDialogue("Memory2Complete");
                    break;
                default:

                    break;
            }
        }
    }
    public void TowerOpen() {
        if (activeSceneName == "World") {
            TowerAnim1 = Tower1.GetComponent<Animator>();
            TowerAnim2 = Tower2.GetComponent<Animator>();

            TowerAudio1 = Tower1.GetComponent<AudioSource>();
            TowerAudio2 = Tower2.GetComponent<AudioSource>();

            Tower1Box = Tower1.GetComponent<BoxCollider2D>();
            Tower2Box = Tower2.GetComponent<BoxCollider2D>();

            switch (GameManager.Instance.State) {
                case GameManager.GameState.Level01:
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
                    break;

                default:
                    break;
            }
        }

        // Debug.Log("Open Sesame");

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
                GameManager.Instance.UpdateGameState(GameManager.GameState.Level02);
                yield return new WaitForSeconds(33f);
                break;

            case "Lvl_02_Cutscene":
                GameManager.Instance.UpdateGameState(GameManager.GameState.Level03);
                yield return new WaitForSeconds(50f);
                break;

            case "Lvl_03_Cutscene":
                GameManager.Instance.UpdateGameState(GameManager.GameState.EndGame);
                yield return new WaitForSeconds(51f);
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
