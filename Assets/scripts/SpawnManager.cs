using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] enemies;
    private bool spawning;
    private int wave;
    private int enemiesToSpawn;
    private int enemiesSpawned;
    private GameManager gameManager;
    private int enemyType;

    private void Start()
    {
        spawning = false;
        wave = 1; // Primera oleada
        enemiesToSpawn = 2; // Inicia con 2 enemigos
        enemiesSpawned = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        // Espera a que todos los enemigos sean derrotados antes de iniciar la siguiente oleada
        if (!spawning && gameManager.defeatedEnemies == enemiesSpawned)
        {
            // Si ya terminaste la tercera oleada, ganar el juego
            if (wave > 3)
            {
                gameManager.WinGame();
                return;
            }

            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        spawning = true;
        gameManager.defeatedEnemies = 0; // Reiniciar contador de enemigos derrotados
        yield return new WaitForSeconds(4); // Espera antes de iniciar la oleada

        enemiesSpawned = 0;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(2); // Espera entre spawns
        }

        // Aumentar oleada pero no permitir que pase de 3
        wave++;
        if (wave <= 3)
        {
            enemiesToSpawn *= 2; // Duplica la cantidad de enemigos por oleada
        }

        spawning = false;
    }

    void SpawnEnemy()
    {
        int spawnPos = Random.Range(0, spawnPoints.Length);

        // Selección del tipo de enemigo según la oleada
        if (wave == 1)
        {
            enemyType = 0;
        }
        else if (wave < 3)
        {
            enemyType = Random.Range(0, Mathf.Min(enemies.Length, 2));
        }
        else
        {
            enemyType = Random.Range(0, enemies.Length);
        }

        Instantiate(enemies[enemyType], spawnPoints[spawnPos].transform.position, spawnPoints[spawnPos].transform.rotation);
        enemiesSpawned++;
    }
}
