using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Obtener la entrada de movimiento (Horizontal y Vertical)
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Convertir el movimiento en relación con la rotación del jugador (espacio local)
        Vector3 moveRelative = transform.TransformDirection(move) * playerSpeed * Time.deltaTime;

        // Mover el jugador usando MovePosition para evitar acumulación de fuerzas
        rb.MovePosition(rb.position + moveRelative);

        // Desbloquear el cursor cuando se presiona Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
