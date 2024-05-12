using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerObject; // Reference to the player object
    private Vector3 lastPlayerPosition;
    private bool isWorldScene;

    void Start()
    {
        // Check if the player object is assigned
        isWorldScene = playerObject != null;

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
    }

    void LoadGameState()
    {
        // Load the player's last position only if the current scene is the World scene
        if (isWorldScene)
        {
            LoadLastPlayerPosition();
        }
    }
}
