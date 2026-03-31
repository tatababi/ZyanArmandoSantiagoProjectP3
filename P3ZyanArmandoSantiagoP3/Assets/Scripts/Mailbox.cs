using UnityEngine;

public class Mailbox : MonoBehaviour
{
    public GameObject deliveryText;
    public AudioSource winSound; // Assign a win sound here

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 1. Show the message
            if (deliveryText != null) deliveryText.SetActive(true);

            // 2. Play win sound
            if (winSound != null) winSound.Play();

            // 3. Stop Player Movement
            PlayerController moveScript = other.GetComponent<PlayerController>();
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            if (moveScript != null) moveScript.enabled = false; // Stops input
            if (rb != null) rb.velocity = Vector2.zero; // Stops sliding
        }
    }
}