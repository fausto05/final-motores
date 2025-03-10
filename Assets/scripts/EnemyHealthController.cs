using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int currentHealth = 5; // Vida del enemigo
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void DamageEnemy()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            gameManager.defeatedEnemies++; // Incrementar el contador de enemigos derrotados
            Destroy(gameObject); // Eliminar enemigo

            // Verificar si se eliminaron todos los enemigos para ganar el juego
            if (gameManager.defeatedEnemies == 14) 
            {
                gameManager.WinGame();
            }
        }
    }
}
