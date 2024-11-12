using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public Text healthText;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
{
    health -= damage;
    UpdateHealthText();

    Debug.Log("Vida del jugador despu�s del da�o: " + health);

    if (health <= 0)
    {
        Die();
    }
}


    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString();
        }
    }

    void Die()
    {
        Debug.Log("Jugador ha muerto");
        if (gameManager != null)
        {
            gameManager.GameOver(); // Llama al m�todo GameOver en el GameManager
        }
    }
}
