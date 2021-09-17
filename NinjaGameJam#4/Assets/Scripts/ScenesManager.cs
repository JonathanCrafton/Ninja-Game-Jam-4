using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    public void StartGame()
    {
        ShopManager.Instance.GetComponentInChildren<Canvas>().enabled = false;
        SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        //ShopManager.Instance.GetComponentInChildren<Canvas>().enabled = false;

    }

    public void GotoStoryCutscene()
    {
        SceneManager.LoadScene("StoryCutscene", LoadSceneMode.Single);
    }

    public void GotoShop()
    {

        SceneManager.LoadScene("Shop", LoadSceneMode.Single);
        if(ShopManager.Instance.GetComponentInChildren<Canvas>().enabled == false)
            ShopManager.Instance.GetComponentInChildren<Canvas>().enabled = true;
    }

    public void GotoCredits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }

    public void WinScene()
    {
        SceneManager.LoadScene("Win", LoadSceneMode.Single);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }
}
