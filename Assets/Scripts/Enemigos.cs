using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigos : MonoBehaviour
{
    public int health = 100; // Vida inicial del enemigo
    public Transform player; // Referencia al jugador
    private NavMeshAgent agent; // Componente NavMeshAgent

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Obtener el componente NavMeshAgent
        if (player == null)
        {
            // Encuentra al jugador autom�ticamente si no est� configurado
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }
    }

    void Update()
    {
        // Perseguir al jugador si est� configurado
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }

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
        // Efectos de muerte (como part�culas o sonido) pueden ir aqu�
        Destroy(gameObject); // Destruir el enemigo
    }
}
