using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;

    [SerializeField] GameObject enemyPrefab;
    
    void Start()
    {   
        LevelManager.Instance.enemyCount = 0;
        spawnEnemies();
    }

    
    void spawnEnemies()
    {   
        System.Random r = new System.Random();
        for(int i = 0; i < 5; ++i)
        {
            Instantiate(enemyPrefab,spawnPoints[r.Next(spawnPoints.Length)].position, Quaternion.identity);
            ++LevelManager.Instance.enemyCount;
        }
    }
}
