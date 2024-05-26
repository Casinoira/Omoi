using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // public GameObject playerObject; // Reference to the player object
    // private Vector3 lastPlayerPosition;
    // private bool isWorldScene;

    public static GameManager Instance;

    public GameState State;
    public GameObject Player;

    public Vector2 playerSavePosition;

    public static event Action<GameState> OnGameStateChanged;

    void Awake() {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start() {
        UpdateGameState(GameState.NewGame);
    }

    public void UpdateGameState(GameState newState) {
        State = newState;

        switch(newState) {
            case GameState.NewGame:
                playerSavePosition = new Vector2(-73f, -37f);
                break;
            case GameState.Level01:
                break;
            case GameState.Level02:
                break;
            case GameState.Level03:
                break;
            case GameState.EndGame:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    public void LoadNewGame() {
        UpdateGameState(GameState.Level01);
    }

    public void MovePlayerToSavedPosition()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerObject.transform.position = playerSavePosition;
        }

        Debug.Log("Player is moved");
    }

    public enum GameState {
        NewGame,
        Level01,
        Level02,
        Level03,
        EndGame
    }
}