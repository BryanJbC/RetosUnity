using UnityEngine;

public class SpawnerRecolectable : MonoBehaviour
{
    public GameObject[] recolectables;  // Array con los recolectables amarillos y rojos
    public Transform[] spawnPoints;  // Puntos de spawn para los recolectables
    public float spawnInterval = 2f;  // Tiempo entre cada spawn

    void Start()
    {
        InvokeRepeating("SpawnRecolectable", 0f, spawnInterval);  // Invoca la función repetidamente
    }

    void SpawnRecolectable()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);  // Elige un punto de spawn aleatorio
        int recolectableIndex = Random.Range(0, recolectables.Length);  // Elige un recolectable aleatorio

        // Instancia el recolectable en el punto de spawn elegido
        Instantiate(recolectables[recolectableIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
    }
}