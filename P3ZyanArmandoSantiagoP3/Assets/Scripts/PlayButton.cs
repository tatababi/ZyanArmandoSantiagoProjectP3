using UnityEngine;
using UnityEngine.SceneManagement; // Required to change levels

public class PlayButton: MonoBehaviour
{
    // Type your level name in the Inspector (e.g., "Level1")
    public string levelToLoad;

    // This function automatically detects clicks on 2D Colliders
    private void OnMouseDown()
    {
        // 1. Hide the sprite
        gameObject.SetActive(false);

        // 2. Load the next level (optional)
        if (!string.IsNullOrEmpty(levelToLoad))
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
 