using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] enemies;
    public bool spawning;
    private int waveCount;
    private int wave;
    private int enemyType;
    private int enemiesSpawned;
    private GameManager gameManager;

    private void Start()
    {
        spawning = false;
        enemiesSpawned = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (spawning == false && enemiesSpawned == gameManager.defeatedEnemies)
        {
            StartCoroutine(SpawnWave(waveCount));
        }
    }

    IEnumerator SpawnWave(int waveC)
    {
        spawning = true;
        yield return new WaitForSeconds(4);

        for (int i = 0; i < waveC; i++)
        {
            SpawnEnemy(wave);
            yield return new WaitForSeconds(2);
        }
        wave += 1;
        waveCount += 2;
        spawning = false;

        enemiesSpawned = 0;

        yield break;
    }

    void SpawnEnemy(int wave)
    {
        int spawnPos = Random.Range(0, spawnPoints.Length); // Corregido

        if (wave == 1)
        {
            enemyType = 0; // Se selecciona el primer tipo de enemigo
        }
        else if (wave < 4)
        {
            enemyType = Random.Range(0, Mathf.Min(enemies.Length, 2)); // Corregido
        }
        else
        {
            enemyType = Random.Range(0, enemies.Length); // Corregido
        }

        Instantiate(enemies[enemyType], spawnPoints[spawnPos].transform.position, spawnPoints[spawnPos].transform.rotation);
        enemiesSpawned += 1;
    }
}
