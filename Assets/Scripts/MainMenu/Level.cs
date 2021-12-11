using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private Button levelBtn;

    public int levelReq;

    private void Start()
    {
        levelBtn = GetComponent<Button>();   
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("Level", 1) >= levelReq)
        {
            levelBtn.onClick.AddListener(() => LoadLevel());
        }
        else
        {
            GetComponent<CanvasGroup>().alpha = .5f;
        }
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(gameObject.name);
    }
}
