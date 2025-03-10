using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance; // Para acceder al jugador desde otros scripts

    public CharacterController charCon;
    public Transform camTrans;

    [Header("Gravity")]
    public float gravedadModificar; // Controlar la gravedad del personaje

    [Header("Move controls")]
    public float moveSpeed; // Velocidad de movimiento
    public float jumpPower; // Potencia del salto
    private bool canJump; // Saber si el jugador puede saltar
    public Transform groundCheckPoint;
    public LayerMask isGround;

    [Header("Camera controls")]
    public float mouseSensibilidad; // Sensibilidad del mouse
    public bool invertX;
    public bool invertY;

    private Vector3 moveInput;

    public GameObject bullet; // Prefab de la bala
    public Transform firePoint; // Punto desde donde se disparan las balas

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        // Guardar el valor de Y antes de calcular el movimiento
        float yStore = moveInput.y;

        // Movimiento del jugador con WASD
        Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");
        Vector3 horiMove = transform.right * Input.GetAxisRaw("Horizontal");

        moveInput = horiMove + vertMove;
        moveInput.Normalize(); // Evitar que se mueva más rapido en diagonal
        moveInput *= moveSpeed;

        moveInput.y = yStore; // Restaurar la velocidad en Y

        // Aplicar gravedad manualmente
        moveInput.y += Physics.gravity.y * gravedadModificar * Time.deltaTime;

        if (charCon.isGrounded)
        {
            moveInput.y = Physics.gravity.y * gravedadModificar * Time.deltaTime;
        }

        // Verificar si esta tocando el suelo
        canJump = Physics.OverlapSphere(groundCheckPoint.position, .25f, isGround).Length > 0;

        // Salto del jugador
        if (Input.GetButtonDown("Jump") && canJump)
        {
            moveInput.y = jumpPower;
        }

        charCon.Move(moveInput * Time.deltaTime); // Aplicar el movimiento

        // Control de la camara con el mouse
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensibilidad;

        if (invertX) mouseInput.x = -mouseInput.x;
        if (invertY) mouseInput.y = -mouseInput.y;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
        camTrans.rotation = Quaternion.Euler(camTrans.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));

        // Disparar con clic izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}



