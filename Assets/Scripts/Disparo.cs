using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint;         // Punto desde donde se disparan las balas
    public float projectileSpeed = 20f; // Velocidad del proyectil
    

    void Update()
    {
        // Disparar cuando se presiona el bot�n izquierdo del mouse
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar el proyectil en la posici�n y rotaci�n del firePoint
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // A�adir fuerza al proyectil
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * projectileSpeed;
        }

        // Destruir el proyectil despu�s de un tiempo para optimizar el rendimiento
        Destroy(projectile, 3f);
    }

    
}
