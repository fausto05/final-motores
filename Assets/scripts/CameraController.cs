using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // A quien sigue la camara 

    private void LateUpdate()
    {
        // La camara siempre sigue la posicion y rotacion del jugador
        transform.position = target.position;
        transform.rotation = target.rotation;
    }
}
