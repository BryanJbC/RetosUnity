using UnityEngine;

public class RecolectableController : MonoBehaviour
{
    public int scoreChange = 10;  // Cuánto se suma o resta al puntaje
    public bool isPositive = true; // Si es verdadero, aumenta el puntaje; si es falso, lo disminuye

    // Esto se llama cuando el objeto con este collider entra en contacto con otro collider
    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en contacto es el jugador
        if (other.CompareTag("Player"))
        {
            ScorePlayer scorePlayer = other.GetComponent<ScorePlayer>();
            if (scorePlayer != null)
            {
                // Si el recolectable es positivo, aumenta el puntaje; si es negativo, lo disminuye
                if (isPositive)
                {
                    scorePlayer.IncreaseScore(scoreChange);  // Aumenta el puntaje
                }
                else
                {
                    scorePlayer.DecreaseScore(scoreChange);  // Disminuye el puntaje
                }

                Destroy(gameObject); // Destruye el recolectable después de la colisión
            }
        }
    }
}
