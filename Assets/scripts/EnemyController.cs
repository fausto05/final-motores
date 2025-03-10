using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    private Transform player;

    private void Start()
    {
        // Buscar al jugador para perseguirlo
        if (PlayerMovement.Instance != null)
        {
            player = PlayerMovement.Instance.transform;
        }
    }

    private void FixedUpdate()
    {
        if (player == null) return; // Si el jugador no existe, no hacer nada

        // Direccionar al enemigo hacia el jugador
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0; // Evitar que mire hacia arriba o abajo

        // Rotacion suave hacia el jugador
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(Quaternion.Slerp(transform.rotation, lookRotation, Time.fixedDeltaTime * 5));

        // Moverse hacia el jugador
        rb.velocity = transform.forward * moveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector3.zero; // Detener el movimiento para evitar que rebote

            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // Hacer daño al jugador
            }
        }
    }
}
