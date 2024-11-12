using UnityEngine;
using UnityEngine.UI;

public class ScorePlayer : MonoBehaviour
{
    public Text scoreText;  // Referencia al texto en el Canvas
    private int score = 0;  // Puntaje inicial

    void Start()
    {
        // Inicializa el texto del puntaje
        UpdateScoreText();
    }

    // Método para aumentar el puntaje
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();  // Actualiza el texto del puntaje
    }

    // Método para reducir el puntaje
    public void DecreaseScore(int amount)
    {
        score -= amount;
        if (score < 0) score = 0;  // El puntaje no debe ser negativo
        UpdateScoreText();  // Actualiza el texto del puntaje
    }

    // Método para actualizar el texto en el UI
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
