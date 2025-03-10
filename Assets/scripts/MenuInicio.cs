using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None; // Liberar el cursor para que funcione la UI
        Cursor.visible = true; // Asegurar que el cursor sea visible
    }
    public void Jugar()
    {
        SceneManager.LoadScene(1); // Cambia al juego
    }

    public void Salir()
    {
        Application.Quit(); // Cierra la aplicacion
    }

    public void VolverAlMenu()
    {
        Debug.Log("BOTÓN RESTART PRESIONADO");

        // Asegurar que el GameManager no persista después del restart
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            Destroy(gameManager.gameObject);
        }

        Time.timeScale = 1f; // Asegurar que el tiempo no esté pausado
        SceneManager.LoadScene(0); // Cargar la escena del menú principal
    }


}
