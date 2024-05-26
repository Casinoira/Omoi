using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerCopy
 : MonoBehaviour
{
    public GameObject playerObject; // Reference to the player object
    private Vector3 lastPlayerPosition;
    private bool isWorldScene;

    void Start()
    {
        // Check if the player object is assigned
        isWorldScene = playerObject != null;
        
        if(playerObject != null) {
            print("Player existed");
        }

        // Load the game state only if the player object is assigned (i.e., if it's the World scene)
        if (isWorldScene)
        {
            LoadGameState();
        }
    }

    public void SavePlayerPosition(Vector3 position)
    {
        // Save the player's position only if the current scene is the World scene
        if (isWorldScene)
        {
            lastPlayerPosition = position;
        }
    }

    public void LoadLastPlayerPosition()
    {
        // Load the player's last position only if the current scene is the World scene
        if (isWorldScene)
        {
            if (playerObject != null)
            {
                playerObject.transform.position = lastPlayerPosition;
            }
        }
    }

    public void CompleteLevel()
    {
        // Save the game state when the player completes a level
        SaveGameState();

        // Load back to the World scene
        SceneManager.LoadScene("World");
    }

    // Other methods for saving/loading game state...
    public void SaveGame() {
        SaveGameState();
    }

    void SaveGameState()
    {
        // Save the player's position only if the current scene is the World scene
        if (isWorldScene)
        {
            if (playerObject != null)
            {
                SavePlayerPosition(playerObject.transform.position);
            }
        }
        else
        {
            // Save current level scene
            PlayerPrefs.SetString("CurrentLevelScene", SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();
        }
    }

    public void LoadGame()
    {
        // Load the game state when the player clicks on "Load Game" from the main menu
        LoadGameState();
    }

    void LoadGameState()
    {
        // Load the player's last position and level scene only if the current scene is the World scene
        if (isWorldScene)
        {
            LoadLastPlayerPosition();
        }
        else
        {
            // Load saved level scene
            string currentLevelScene = PlayerPrefs.GetString("CurrentLevelScene");
            if (!string.IsNullOrEmpty(currentLevelScene))
            {
                SceneManager.LoadScene(currentLevelScene);
            }
        }
    }
}
