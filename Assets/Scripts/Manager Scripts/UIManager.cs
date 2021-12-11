using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Space(10)]
    [Header("Bullet UI")]
    public GameObject blackBullet;
    public GameObject goldenBullet;
    private GameObject bullets;

    private List<GameObject> goldenBulletUI = new List<GameObject>();
    private List<GameObject> blackBulletUI = new List<GameObject>();

    [Space(10)]
    [Header("WinScreen")]
    public Text winText;
    public GameObject winPanel;
    public Image star1, star2, star3;
    public Sprite shineStar, darkStar;

    [Space(10)]
    [Header("GameOver")]
    public GameObject gameOverPanel;


    private PlayerController playerController;

    private void Awake()
    {
        instance = this;
        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.SetActive(false);
        bullets = GameObject.Find("Bullets");
        playerController = FindObjectOfType<PlayerController>();
        winPanel.SetActive(false);
    }
    private void Start()
    {
        CreateBulletUI(playerController.blackBullets, playerController.goldenBullets);
    }
    private void CreateBulletUI(int blackBullets, int goldenBullets)
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

    public void CheckBulletUI(ref int blackBullets, ref int goldenBullets)
    {
        if (goldenBullets > 0)
        {
            goldenBulletUI[goldenBullets - 1].GetComponent<CanvasGroup>().alpha = 0.3f;
            goldenBullets--;
        }
        else if (blackBullets > 0)
        {
            blackBulletUI[blackBullets - 1].GetComponent<CanvasGroup>().alpha = 0.3f;
            blackBullets--;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Win()
    {
        if(playerController.ammo >= playerController.startingAmmo - 1)
        {
            star1.GetComponent<Image>().sprite = shineStar;
            star2.GetComponent<Image>().sprite = shineStar;
            star3.GetComponent<Image>().sprite = shineStar;
        }
        else if(playerController.ammo >= playerController.startingAmmo - 2)
        {
            star1.GetComponent<Image>().sprite = shineStar;
            star2.GetComponent<Image>().sprite = shineStar;
            star3.GetComponent<Image>().sprite = darkStar;
        }
        else if(playerController.ammo >= playerController.startingAmmo - 3)
        {
            star1.GetComponent<Image>().sprite = shineStar;
            star2.GetComponent<Image>().sprite = darkStar;
            star3.GetComponent<Image>().sprite = darkStar;
        }
        else
        {
            star1.GetComponent<Image>().sprite = darkStar;
            star2.GetComponent<Image>().sprite = darkStar;
            star3.GetComponent<Image>().sprite = darkStar;
        }
        winPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
