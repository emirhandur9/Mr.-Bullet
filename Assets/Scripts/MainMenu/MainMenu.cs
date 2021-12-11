using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject play, levelSelection;

    public void PlayGame()
    {
        play.SetActive(false);
        levelSelection.SetActive(true);
    }
}
