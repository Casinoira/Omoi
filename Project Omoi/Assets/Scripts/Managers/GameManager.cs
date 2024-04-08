using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;
    void Awake() {
        Instance = this;    
    }

    void Start() {
        UpdateGameState(GameState.GenerateGrid);
    }

    public void UpdateGameState(GameState newState) {
        State = newState;

        switch (newState) {
            case GameState.GenerateGrid:
                gridManager.Instance.GenerateGrid();
                break;
            case GameState.GameStart:
                break;
            case GameState.GameOver:
                // ballControl.Instance.RestartScene();
                break;
            case GameState.GameCompleted:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }
}

public enum GameState {
    GenerateGrid,
    GameStart,
    GameOver,
    GameCompleted
}