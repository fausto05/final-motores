using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public int damage = 25; // Da�o que el proyectil inflige

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto impactado tiene el script "Enemigos"
        Enemigos enemy = collision.gameObject.GetComponent<Enemigos>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Aplicar da�o al enemigo
        }

        // Destruir el proyectil despu�s del impacto
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        // Alternativa para detectar enemigos si usas Triggers en lugar de Colliders
        Enemigos enemy = other.GetComponent<Enemigos>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Aplicar da�o al enemigo
            Destroy(gameObject); // Destruir el proyectil
        }
    }
}

