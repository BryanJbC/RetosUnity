using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;              // Referencia al jugador
    public float moveSpeed = 3f;          // Velocidad de movimiento
    public float followRange = 10f;       // Rango de seguimiento (distancia en la que el enemigo comienza a seguir al jugador)
    public float attackRange = 1.5f;      // Rango de ataque (distancia en la que el enemigo puede atacar al jugador)
    public int health = 100;              // Salud del enemigo

    private bool isAttacking = false;     // Verifica si el enemigo está atacando
    private Animator animator;            // Referencia al Animator (si tienes animaciones de movimiento)
    private bool isMoving = false;        // Verifica si el enemigo se está moviendo

    void Start()
    {
        // Inicializar el Animator (si lo estás utilizando)
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            // Calculamos la distancia entre el enemigo y el jugador
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Si el jugador está dentro del rango de persecución
            if (distanceToPlayer <= followRange)
            {
                // El enemigo sigue al jugador
                MoveTowardsPlayer();

                // Si el jugador está dentro del rango de ataque, se detiene para atacar
                if (distanceToPlayer <= attackRange && !isAttacking)
                {
                    isAttacking = true;
                    AttackPlayer();
                }
            }
            else
            {
                // Si el enemigo está fuera de rango, detiene el ataque
                isAttacking = false;
                StopMoving();
            }
        }
    }

    // Método para mover al enemigo hacia el jugador
    private void MoveTowardsPlayer()
    {
        // Obtén la dirección en la que el enemigo se mueve (sin considerar la altura)
        Vector3 direction = player.position - transform.position;
        direction.y = 0; // Asegúrate de que el enemigo no se mueva hacia arriba o hacia abajo

        // Normalizamos la dirección y la multiplicamos por la velocidad de movimiento
        Vector3 move = direction.normalized * moveSpeed * Time.deltaTime;

        // Mueve al enemigo
        transform.Translate(move, Space.World);

        // Control de rotación hacia el jugador solo si el enemigo está moviéndose
        if (isMoving)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 180 * Time.deltaTime);
        }

        // Si tienes animaciones, puedes agregar una animación de movimiento aquí
        if (animator != null)
        {
            animator.SetBool("isWalking", true);  // Cambia "isWalking" por el nombre de tu parámetro de animación
        }
        isMoving = true;
    }

    // Método para detener el movimiento
    private void StopMoving()
    {
        isMoving = false;
        if (animator != null)
        {
            animator.SetBool("isWalking", false);  // Detiene la animación de caminar
        }
    }

    // Método para atacar al jugador (puedes agregar lógica de daño aquí si lo necesitas)
    private void AttackPlayer()
    {
        // Aquí puedes agregar la lógica para atacar, como restar vida al jugador
        if (animator != null)
        {
            animator.SetBool("isWalking", false);  // Detiene la animación de caminar
            animator.SetTrigger("Attack");         // Cambia "Attack" por el nombre de tu parámetro de ataque
        }

        // Ejemplo de daño (esto requiere que tengas un script de salud en el jugador)
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(10);  // Reduce 10 de vida al jugador
        }
    }

    // Método para recibir daño
    public void TakeDamage(int damage)
    {
        health -= damage;

        // Si la salud es menor o igual a cero, el enemigo muere
        if (health <= 0)
        {
            Die();
        }
    }

    // Método para destruir al enemigo cuando muere
    private void Die()
    {
        if (animator != null)
        {
            animator.SetTrigger("Die");  // Activa la animación de muerte
        }

        // Aquí podrías agregar otros efectos, como destruir el objeto enemigo
        Destroy(gameObject);  // Destruye el enemigo
    }
}
