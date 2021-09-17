using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private BoardManager boardScript;


    private void Awake()
    {
        boardScript = GetComponent<BoardManager>();
    }

    void Start()
    {
        boardScript.SetupScene();
        GameManager.Instance.woodCount = 0;
        GameManager.Instance.woodText.text = ": 0";
        GameManager.Instance.time = 0;
    }

}
