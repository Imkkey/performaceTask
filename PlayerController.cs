using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int maxHealth = 3; 
    public int currentHealth; 
    Rigidbody2D rb2d;
    public Text healthText; 
    public GameObject gameOverPanel;

    void Start()
    {
        Time.timeScale = 1;
        rb2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; 
        HealthUI();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        MovePlayer(horizontalInput);
    }

    private void MovePlayer(float horizontalInput)
    {
        Vector2 moveDirection = new Vector2(horizontalInput * moveSpeed, rb2d.linearVelocity.y);
        rb2d.linearVelocity = moveDirection;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            TakeDamage(1);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthUI();
        Debug.Log($"HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void HealthUI()
    {
        if (healthText != null)
        {
            healthText.text = $"HP: {currentHealth}";
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
