using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LevelManager : MonoBehaviour
{

    [SerializeField] Transform[] spawnPoints;

    [SerializeField] GameObject enemyPrefab;
    
    public int BombCount = 0;
    public int enemyCount = 0;
    public bool isPlayerDead = false;
    
    public static LevelManager Instance;

    void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        spawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnEnemies()
    {   
        System.Random r = new System.Random();
        for(int i = 0; i < 5; ++i)
        {
            Instantiate(enemyPrefab,spawnPoints[r.Next(spawnPoints.Length)].position, Quaternion.identity);
        }
    }
    
}
