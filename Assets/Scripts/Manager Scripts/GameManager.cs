using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int enemyCount = 1;

    [HideInInspector]
    public bool gameOver;

    public static GameManager instance;
    private PlayerController playerController;

    private int levelNumber;

    private void Awake()
    {
        instance = this;
        playerController = FindObjectOfType<PlayerController>();
        levelNumber = PlayerPrefs.GetInt("Level", 1);
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
            if (levelNumber >= SceneManager.GetActiveScene().buildIndex)
            {
                PlayerPrefs.SetInt("Level", levelNumber + 1);   
            }
        }
    }

    

    
}
