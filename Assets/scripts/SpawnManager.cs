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
        wave = 1; // Comenzar en la primera oleada
        enemiesToSpawn = 2; // Iniciar con 2 enemigos
        enemiesSpawned = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        // Esperar a que todos los enemigos sean derrotados antes de iniciar la siguiente oleada
        if (!spawning && gameManager.defeatedEnemies == enemiesSpawned)
        {
            if (wave > 3) // Si ya termino la tercera oleada, el jugador gana
            {
                gameManager.WinGame();
                return;
            }

            StartCoroutine(SpawnWave());
        }
    }

    private IEnumerator SpawnWave()
    {
        spawning = true;
        gameManager.defeatedEnemies = 0; // Reiniciar el contador de enemigos derrotados
        yield return new WaitForSeconds(4); // Esperar antes de empezar la oleada

        enemiesSpawned = 0;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(2); // Esperar entre spawns
        }

        wave++;
        if (wave <= 3)
        {
            enemiesToSpawn *= 2; // Duplicar la cantidad de enemigos en cada oleada
        }

        spawning = false;
    }

    private void SpawnEnemy()
    {
        int spawnPos = Random.Range(0, spawnPoints.Length);

        // Determinar que tipo de enemigo generar segun la oleada
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
