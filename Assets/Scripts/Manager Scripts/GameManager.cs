using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int enemyCount = 1;

    [HideInInspector]
    public bool gameOver;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if(!gameOver && FindObjectOfType<PlayerController>().ammo <= 0 && enemyCount > 0)
        {
            gameOver = true;
        }
    }

    public void CheckEnemyCount()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("EnemyItself").Length;


        if(enemyCount <= 0)
        {
            print("WÝN");
        }
    }
}
