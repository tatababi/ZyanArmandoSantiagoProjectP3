using UnityEngine;
using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required to change the Image component

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    [Header("I-Frames")]
    public float invincibilityDuration = 1.5f;
    private bool isInvincible = false;

    [Header("UI Settings")]
    public Image heartImage; // Drag your Heart Image from the Canvas here
    public Sprite[] heartSprites; // Drag your 3 sprites into this list
    public GameObject gameOverPanel;

    void Start()
    {
        currentHealth = maxHealth;
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        UpdateHealthUI();
    }

    public void TakeDamage(int amount)
    {
        if (isInvincible) return;

        currentHealth -= amount;
        UpdateHealthUI();

        if (currentHealth <= 0) Die();
        else StartCoroutine(BecomeInvincible());
    }

    private IEnumerator BecomeInvincible()
    {
        isInvincible = true;
        // Optional: blink the heart or player here
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    void UpdateHealthUI()
    {
        if (heartImage != null && heartSprites.Length > 0)
        {
            // If health is 3, we show heartSprites[2] (index starts at 0)
            // If health is 1, we show heartSprites[0]
            int spriteIndex = Mathf.Clamp(currentHealth - 1, 0, heartSprites.Length - 1);

            if (currentHealth > 0)
            {
                heartImage.sprite = heartSprites[spriteIndex];
            }
            else
            {
                // Optional: Hide the heart or show an empty heart sprite at 0 hp
                heartImage.enabled = false;
            }
        }
    }

    void Die()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }
}