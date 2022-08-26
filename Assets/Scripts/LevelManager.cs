using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LevelManager : MonoBehaviour
{

    
    
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
            this.enemyCount = 0;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
}
