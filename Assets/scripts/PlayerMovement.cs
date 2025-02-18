using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    
    public CharacterController charCon;
    public Transform camTrans;

    [Header("Gravity")]
    public float gravedadModificar;

    [Header("Move controls")]
    public float moveSpeed;
    public float jumpPower;
    private bool canJump;
    public Transform groundCheckPoint;
    public LayerMask isGround; 

    [Header("Camera controls")]
    public float mouseSensibilidad;
    public bool invertX;
    public bool invertY;

    private Vector3 moveInput;

    public GameObject bullet;
    public Transform firePoint;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        //moveInput.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //moveInput.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        //Guardar Y velocity
        float yStore = moveInput.y;

        Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");
        Vector3 horiMove = transform.right * Input.GetAxisRaw("Horizontal");

        moveInput = horiMove + vertMove;
        moveInput.Normalize();
        moveInput = moveInput * moveSpeed;

        moveInput.y = yStore;

        //Gravedad
        moveInput.y += Physics.gravity.y * gravedadModificar * Time.deltaTime;
        
        if (charCon.isGrounded)
        {
            moveInput.y = Physics.gravity.y * gravedadModificar * Time.deltaTime;
        }
        
        canJump = Physics.OverlapSphere(groundCheckPoint.position, .25f, isGround).Length > 0;
        
        //Salto del jugador
        if (Input.GetButtonDown("Jump") && canJump)
        {
            moveInput.y = jumpPower;    
        }

        charCon.Move(moveInput * Time.deltaTime);

        //Control rotación cámara
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensibilidad;
        
        if (invertX)
        {
            mouseInput.x = -mouseInput.x;
        }
        if (invertY)
        {
            mouseInput.y = -mouseInput.y;
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        camTrans.rotation = Quaternion.Euler(camTrans.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));

        //Shooting
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}


