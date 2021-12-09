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
    private PlayerController player;

    public int blackBullets = 3;
    public int goldenBullets = 1;

    public GameObject blackBullet, goldenBullet;
    private GameObject bullets;

    private List<GameObject> goldenBulletUI = new List<GameObject>();
    private List<GameObject> blackBulletUI = new List<GameObject>();

    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<PlayerController>();
        player.ammo = blackBullets + goldenBullets;
        bullets = GameObject.Find("Bullets");

        CreateBulletUI();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if(!gameOver && player.ammo <= 0 && enemyCount > 0)
        {
            gameOver = true;
        }
    }

    private void CreateBulletUI()
    {
        for (int i = 0; i < blackBullets; i++)
        {
            GameObject bbTemp = Instantiate(blackBullet);
            bbTemp.transform.SetParent(bullets.transform);
            blackBulletUI.Add(bbTemp);
        }

        for (int i = 0; i < goldenBullets; i++)
        {
            GameObject bbTemp = Instantiate(goldenBullet);
            bbTemp.transform.SetParent(bullets.transform);
            goldenBulletUI.Add(bbTemp);
        }
    }

    public void CheckBulletUI()
    {
        if(goldenBullets > 0)
        {
            goldenBulletUI[goldenBullets - 1].GetComponent<CanvasGroup>().alpha = 0.3f;
            goldenBullets--;
        }
        else if(blackBullets > 0)
        {
            blackBulletUI[blackBullets - 1].GetComponent<CanvasGroup>().alpha = 0.3f;
            blackBullets--;
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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
