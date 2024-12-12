using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float health = 100f; // Vida inicial del enemigo

    // Método para recibir daño
    public void TakeDamage(float damage)
    {
        health -= damage; // Reducir la vida del enemigo
        Debug.Log("Enemigo recibió daño. Vida restante: " + health);

        if (health <= 0f)
        {
            Die(); // Eliminar al enemigo si su vida llega a 0
        }
    }

    void Die()
    {
        Debug.Log("Enemigo eliminado: " + gameObject.name);
        Destroy(gameObject); // Destruir al enemigo
    }
}
