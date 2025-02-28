using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int currentHealth = 5;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DamageEnemy()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            gm.defeatedEnemies++;  // Incrementa el contador de enemigos derrotados

            Destroy(gameObject);
        }
    }
}
