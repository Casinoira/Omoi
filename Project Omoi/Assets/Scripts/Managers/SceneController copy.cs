// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.Video;

// public class SceneControllerCopy : MonoBehaviour
// {
//     public static SceneController Instance;
//     public GameManager gameManager;
//     public Animator transition;
//     public float transitionTime = 1f;

//     public GameObject memoryBall;
//     public VideoPlayer videoPlayer;

//     private string activeSceneName;

//     void Awake()
//     {
//         activeSceneName = SceneManager.GetActiveScene().name;
        
//         if (videoPlayer != null) {
//             Debug.Log("Starting video playback...");
//             videoPlayer.Play();
//             StartCoroutine(WaitForVideoToEndAndLoadWorld());
//             // LoadWorldLevel();
//         }

//     }

//     void Update() {     
//         if (activeSceneName == "Level_01" || activeSceneName == "Level_02" || activeSceneName == "Level_03") {
//             if (memoryBall == null || memoryBall.Equals(null) || !memoryBall.activeSelf) {
//                 LoadCutsceneLevel();
//             }
//         }
//     }

//     public void LoadLevel(int levelIndex){
//         StartCoroutine(LoadPinballLevel(levelIndex));
//     }

//     public void LoadCutsceneLevel() {
//         StartCoroutine(LoadCutscene());
//     }

//     IEnumerator LoadPinballLevel(int levelIndex) {
//         transition.SetTrigger("Start");

//         yield return new WaitForSeconds(transitionTime);

//         string activeSceneName = SceneManager.GetActiveScene().name;

//         SceneManager.LoadScene(levelIndex);

//     }

//     IEnumerator LoadCutscene() {
//         transition.SetTrigger("Start");

//         yield return new WaitForSeconds(transitionTime);

//         switch (activeSceneName) {
//             case "Level_01":
//                 SceneManager.LoadScene("Lvl_01_Cutscene");
//                 break;

//             case "Level_02":
//                 SceneManager.LoadScene("Lvl_02_Cutscene");
//                 break;

//             case "Level_03":
//                 SceneManager.LoadScene("Lvl_03_Cutscene");
//                 break;

//             default:
//                 break;

//         }
//     }

//     IEnumerator WaitForVideoToEndAndLoadWorld()
//     {
//         switch (activeSceneName) {
//             case "Level_01_Cutscene":
//                 yield return new WaitForSeconds(33f);
//                 GameManager.Instance.UpdateGameState(GameState.Level02);
//                 break;

//             case "Level_02_Cutscene":
//                 yield return new WaitForSeconds(50f);
//                 // gameManager.OnGameStateChanged.Level02;
//                 break;

//             case "Level_03_Cutscene":
//                 yield return new WaitForSeconds(54f);
//                 // gameManager.OnGameStateChanged.Level03;
//                 break;

//             default:
//                 break;

//         }

//         transition.SetTrigger("Start");

//         yield return new WaitForSeconds(transitionTime);

//         SceneManager.LoadScene("World");
//     }
// }
