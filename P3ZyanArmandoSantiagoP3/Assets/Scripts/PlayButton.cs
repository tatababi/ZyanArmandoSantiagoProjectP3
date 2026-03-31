using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public string levelToLoad;
    public AudioClip clickSound;

    [Range(0f, 1f)] // Creates a nice slider in the Inspector
    public float volume = 1f;

    private void OnMouseDown()
    {
        if (clickSound != null)
        {
            // The third value (volume) sets the loudness
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position, volume);
        }

        gameObject.SetActive(false);

        if (!string.IsNullOrEmpty(levelToLoad))
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}