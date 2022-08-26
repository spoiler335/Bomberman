using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text enemyCountText;
    void Start()
    {
        
    }

    
    void Update()
    {
        enemyCountText.text = "Enemy Count : " + LevelManager.Instance.enemyCount;
    }
}
