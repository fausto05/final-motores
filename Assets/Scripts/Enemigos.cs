using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public int health = 100; // Vida inicial del enemigo

    public void TakeDamage(int damage)
    {
        health -= damage; // Reducir la vida

        if (health <= 0)
        {
            Die(); // Si la vida llega a 0, destruir el enemigo
        }
    }

    void Die()
    {
        // Efectos de muerte (como partículas o sonido) pueden ir aquí
        Destroy(gameObject); // Destruir el enemigo
    }
}
