using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image rellenoDeVida; // Imagen de la barra de vida
    private PlayerHealth playerHealth;
    private float vidaMaxima;

    private void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        vidaMaxima = playerHealth.currentHealth;
    }

    private void Update()
    {
        // Actualizar la barra de vida segun la vida actual del jugador
        rellenoDeVida.fillAmount = playerHealth.currentHealth / vidaMaxima;
    }
}
