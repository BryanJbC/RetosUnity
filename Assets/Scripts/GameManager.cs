using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas; // Asigna el Canvas de Game Over en el Inspector
    public bool isGameOver = false;   // Variable para verificar si el juego ha terminado

    void Start()
    {
        gameOverCanvas.SetActive(false); // Desactiva el Canvas al iniciar el juego
        isGameOver = false;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true); // Activa el Canvas de Game Over
        isGameOver = true; // Indica que el juego ha terminado
        Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor
        Cursor.visible = true;
    }

    public void Retry()
    {
        Debug.Log("Botón de Reintentar presionado");
        isGameOver = false;  // Reinicia el estado de juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena actual
    }
}
