using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint;         // Punto desde donde se disparan las balas
    public float projectileSpeed = 50f; // Aumenté la velocidad del proyectil a un valor más alto

    void Update()
    {
        // Disparar cuando se presiona el botón izquierdo del mouse
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Verificar si el firePoint está configurado correctamente
        if (firePoint == null)
        {
            Debug.LogError("FirePoint no está configurado en el script Disparo.");
            return;
        }

        // Instanciar el proyectil en la posición y rotación del firePoint
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Añadir fuerza al proyectil
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * projectileSpeed;
        }

        // Destruir el proyectil después de un tiempo para optimizar el rendimiento
        Destroy(projectile, 3f);
    }


}
