using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth = 10;  // Vida inicial del jugador

    private void Update()
    {
        // Opcional: verifica si la vida llega a cero y maneja la muerte del jugador
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Vida del jugador: " + currentHealth);
    }
}
