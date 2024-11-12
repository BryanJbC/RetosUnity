using UnityEngine;

public class ProyectileController : MonoBehaviour
{
    public float speed = 100f; // Velocidad del proyectil
    public int damage = 10;    // Daño al enemigo

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;  // Desactiva la gravedad para el proyectil
            rb.linearVelocity = transform.forward * speed;  // Ajusta la velocidad en la dirección hacia adelante
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Aplica el daño al enemigo
                Debug.Log("¡Daño al enemigo!");
            }
        }
        // Destruye el proyectil después de la colisión
        Destroy(gameObject);
    }
}
