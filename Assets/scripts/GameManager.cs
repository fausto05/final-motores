using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int defeatedEnemies; // Contador de enemigos derrotados

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Ocultar y bloquear el cursor
        ResetGame();
    }

    public void WinGame()
    {
        SceneManager.LoadScene(2); // Cargar la pantalla de victoria
    }

    public void LoseGame()
    {
        SceneManager.LoadScene(3); // Cargar la pantalla de derrota
    }

    public void ResetGame()
    {
        defeatedEnemies = 0; // Reiniciar el contador de enemigos
    }
}
