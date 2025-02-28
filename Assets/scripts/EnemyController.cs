using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    private Transform player;

    void Start()
    {
        // Buscar al jugador si no tienes una referencia directa
        if (PlayerMovement.Instance != null)
        {
            player = PlayerMovement.Instance.transform;
        }
    }

    void FixedUpdate()
    {
        if (player == null) return; // Evita errores si el jugador no ha sido asignado

        // Hacer que el enemigo mire al jugador
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0; // Evita que mire hacia arriba o abajo

        // Rotar suavemente hacia el jugador
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(Quaternion.Slerp(transform.rotation, lookRotation, Time.fixedDeltaTime * 5));

        // Mover hacia adelante en la dirección en la que está mirando
        rb.velocity = transform.forward * moveSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector3.zero; // Detener el movimiento para evitar el efecto de "globo"

            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);  // Inflige 1 de daño al jugador
            }
        }
    }
}
