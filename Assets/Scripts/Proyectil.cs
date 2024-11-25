using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public int damage = 25; // Daño que el proyectil inflige

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto impactado tiene el script "Enemy"
        Enemigos enemy = collision.gameObject.GetComponent<Enemigos>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Aplicar daño al enemigo
        }

        // Destruir el proyectil después del impacto
        Destroy(gameObject);
    }
}

