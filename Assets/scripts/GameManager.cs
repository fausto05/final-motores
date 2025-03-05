using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int defeatedEnemies;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        defeatedEnemies = 0;
    }

    public void WinGame()
    {
        Debug.Log("¡Has ganado el juego!");
        // Aquí puedes agregar lógica para mostrar una pantalla de victoria
    }
}
