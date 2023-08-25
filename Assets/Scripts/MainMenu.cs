using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsMenu;
    public GameObject loreMenu;

    public void PlayButton()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void SetCreditsVis(bool val)
    {
        creditsMenu.SetActive(val);
    }

    public void NewGame()
    {
        loreMenu.SetActive(true);
    }
}