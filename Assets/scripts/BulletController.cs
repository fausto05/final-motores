using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed, lifeTime; // Velocidad y tiempo de vida de la bala
    public Rigidbody rb;
    public GameObject impactEffect; // Efecto visual al impactar

    private void Update()
    {
        rb.velocity = transform.forward * moveSpeed; // Mover la bala en la direccion en la que fue disparada

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject); // Destruir la bala si dura demasiado
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(); // Hacer daño al enemigo
        }

        Instantiate(impactEffect, transform.position, transform.rotation); // Crear efecto de impacto
        Destroy(gameObject); // Destruir la bala despues del impacto
    }
}
