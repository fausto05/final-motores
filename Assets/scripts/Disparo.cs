using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject balaPrefab; // Prefab de la bala
    public Transform firePoint;     // Punto de disparo
    public float velocidadBala = 20f; // Velocidad de la bala
    public float tiempoBala = 2f; // Tiempo de vida de la bala

    void Update()
    {
        // Detecta si se presiona el botón de disparo
        if (Input.GetButtonDown("Fire1")) // Usa el botón configurado en Input Manager, típicamente clic izquierdo
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar la bala en el firePoint
        GameObject bullet = Instantiate(balaPrefab, firePoint.position, firePoint.rotation);

        // Aplicar movimiento a la bala
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.velocity = transform.forward * velocidadBala;
        }

        // Destruir la bala después de un tiempo
        Destroy(bullet, tiempoBala);
    }
}
