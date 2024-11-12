using UnityEngine;
using UnityEngine.UI;  // Para poder usar la UI

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;  // Salud del enemigo
    public int shield = 50;   // Escudo del enemigo
    public Slider healthSlider;  // Slider de la salud
    public Slider shieldSlider;  // Slider del escudo

    void Start()
    {
        // Inicializa los sliders
        if (healthSlider != null)
        {
            healthSlider.maxValue = health; // Establece el valor máximo de la salud
            healthSlider.value = health;   // Establece el valor actual de la salud
        }
        if (shieldSlider != null)
        {
            shieldSlider.maxValue = shield;  // Establece el valor máximo del escudo
            shieldSlider.value = shield;     // Establece el valor actual del escudo
        }
    }

    public void TakeDamage(int damage)
    {
        if (shield > 0)
        {
            shield -= damage;  // Aplica daño al escudo
            if (shield < 0)
            {
                shield = 0;
            }
            if (shieldSlider != null)
            {
                shieldSlider.value = shield; // Actualiza el slider del escudo
            }
        }
        else
        {
            health -= damage;  // Aplica daño a la salud si no queda escudo
            if (healthSlider != null)
            {
                healthSlider.value = health; // Actualiza el slider de la salud
            }
        }

        // Si la salud llega a 0, destruye al enemigo
        if (health <= 0)
        {
            Die();
        }

        Debug.Log("Vida: " + health + " Escudo: " + shield);
    }

    void Die()
    {
        Debug.Log("El enemigo ha muerto");
        Destroy(gameObject);  // Destruye el enemigo cuando su salud llega a 0
    }
}
