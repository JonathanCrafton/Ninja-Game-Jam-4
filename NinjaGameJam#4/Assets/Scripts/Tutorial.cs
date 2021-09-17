using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    //public ShopManager sm;

    public void GotoShop()
    {
        //if (sm.GetComponentInChildren<Canvas>().enabled == false)
        //sm.GetComponentInChildren<Canvas>().enabled = true;

        SceneManager.LoadScene("Shop", LoadSceneMode.Single);
    }
}
