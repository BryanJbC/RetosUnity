using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;             // Velocidad de movimiento del jugador
    public float jumpHeight = 2f;        // Altura del salto
    public float gravity = -9.81f;       // Fuerza de gravedad
    public float mouseSensitivity = 2f;  // Sensibilidad del mouse

    private CharacterController controller;
    private Vector3 velocity;            // Control de la velocidad vertical
    private bool isGrounded;             // Verifica si el jugador est� en el suelo
    private float verticalRotation = 0f; // Control de la rotaci�n vertical de la c�mara

    void Start()
    {
        // Obtener el CharacterController del jugador
        controller = GetComponent<CharacterController>();

        // Bloquear y ocultar el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Verificar si el jugador est� en el suelo
        isGrounded = controller.isGrounded;

        // Si est� en el suelo y la velocidad en Y es negativa, la reseteamos para mantener al jugador en el suelo
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Un valor ligeramente negativo para mantener el jugador en contacto con el suelo
        }

        // Movimiento del jugador en los ejes X y Z
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Aplicamos el movimiento al CharacterController
        controller.Move(move * speed * Time.deltaTime);

        // Salto
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("Saltar - Velocidad en Y: " + velocity.y);
        }

        // Aplicar gravedad constantemente
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Movimiento de la c�mara con el mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotaci�n vertical de la c�mara (eje X)
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Rotaci�n horizontal del jugador (eje Y)
        transform.Rotate(Vector3.up * mouseX);
    }
}
