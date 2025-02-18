using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(PlayerMovement.Instance.transform.position);

        rb.velocity = transform.forward * moveSpeed;
    }
}
