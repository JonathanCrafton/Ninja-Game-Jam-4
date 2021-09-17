using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StoryCutscene : MonoBehaviour
{
    public Text[] textBlocks;
    private int index = 0;
    //public ScenesManager sm;

    public void nextTextBlock()
    {
        if (index <= textBlocks.Length - 1)
        {
            Debug.Log(index);
            textBlocks[index].enabled = false;
            if(index < textBlocks.Length - 1)
            {
                index++;
            }
            textBlocks[index].enabled = true;
        }
        else
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    
}
