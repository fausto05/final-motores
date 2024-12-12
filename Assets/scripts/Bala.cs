using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float damage = 25f; // Daño que inflige la bala
    
    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto con el que colisiona es un enemigo
        Enemigo enemy = other.GetComponent<Enemigo>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Aplicar daño al enemigo
        }

        // Destruir la bala al impactar
        Destroy(gameObject);
    }
}
