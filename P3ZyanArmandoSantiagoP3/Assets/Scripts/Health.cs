using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    // Drag your Game Over Panel from the Hierarchy into this slot in the Inspector
    public GameObject gameOverPanel;

    void Start()
    {
        currentHealth = maxHealth;
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Dead!");
        // Show the Game Over screen
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        
    }
}



