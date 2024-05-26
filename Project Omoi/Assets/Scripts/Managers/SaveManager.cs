// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class SaveManager : MonoBehaviour
// {
//     // Array to store level completion status
//     bool[] levelCompleted;

//     void Start()
//     {
//         LoadGameProgress();
//     }

//     // Method to save game progress
//     public void SaveGameProgress()
//     {
//         // Assuming you have a LevelManager script that manages levels and portals
//         LevelManager levelManager = FindObjectOfType<LevelManager>();

//         // Update level completion status
//         levelCompleted = new bool[levelManager.portalCount];
//         for (int i = 0; i < levelManager.portalCount; i++)
//         {
//             levelCompleted[i] = levelManager.IsLevelCompleted(i); // Assuming IsLevelCompleted method checks completion status
//         }

//         // Save level completion status
//         for (int i = 0; i < levelCompleted.Length; i++)
//         {
//             PlayerPrefs.SetInt("Level_" + i, levelCompleted[i] ? 1 : 0);
//         }

//         PlayerPrefs.Save();
//     }

//     // Method to load game progress
//     public void LoadGameProgress()
//     {
//         LevelManager levelManager = FindObjectOfType<LevelManager>();

//         levelCompleted = new bool[levelManager.portalCount];
//         for (int i = 0; i < levelCompleted.Length; i++)
//         {
//             levelCompleted[i] = PlayerPrefs.GetInt("Level_" + i, 0) == 1; // Default to not completed if key doesn't exist
//         }
//     }

//     // Method to get the spawn position of the player
//     public Vector3 GetPlayerSpawnPosition()
//     {
//         LevelManager levelManager = FindObjectOfType<LevelManager>();
//         int lastCompletedLevel = 0;

//         // Find the last completed level
//         for (int i = 0; i < levelCompleted.Length; i++)
//         {
//             if (levelCompleted[i])
//             {
//                 lastCompletedLevel = i;
//             }
//         }

//         // Return the spawn position on top of the portal of the last completed level
//         return levelManager.GetPortalPosition(lastCompletedLevel);
//     }
// }