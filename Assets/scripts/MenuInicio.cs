using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(1); // Cambia al juego
    }

    public void Salir()
    {
        Application.Quit(); // Cierra la aplicacion
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0); // Regresa al menú principal
    }
}
