using UnityEngine;
using System;
public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint; // El punto de origen del disparo
    public GameObject projectilePrefab; // Prefab del proyectil
    public float projectileSpeed = 20f; // Velocidad del proyectil

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Fire1 es el bot�n izquierdo del rat�n
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Crear un nuevo proyectil en el FirePoint y orientado en su direcci�n
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * projectileSpeed; // Disparar hacia adelante
        }
    }
}
