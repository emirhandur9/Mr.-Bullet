using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public int enemyCount = 1;

    [HideInInspector]
    public bool gameOver;

    public static GameManager instance;
    private PlayerController playerController;


    private void Awake()
    {
        instance = this;
        playerController = FindObjectOfType<PlayerController>();
    }


    private void Update()
    {
        if(!gameOver && playerController.ammo <= 0 && enemyCount > 0 && GameObject.FindGameObjectsWithTag("Bullet").Length <= 0)
        {
            gameOver = true;
            UIManager.instance.gameOverPanel.SetActive(true);
        }
    }


    public void CheckEnemyCount()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("EnemyItself").Length;


        if(enemyCount <= 0)
        {
            UIManager.instance.Win();
        }
    }

    

    
}
