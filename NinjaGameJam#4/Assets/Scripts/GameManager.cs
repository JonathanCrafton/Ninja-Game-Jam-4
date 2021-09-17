using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    

    public int woodCount;
    public Text woodText;

    public float time = 0.0f;
    public Text timer;
    
    private BoardManager boardScript;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        
    }

    public void Start()
    {
        woodCount = 0;
        woodText.text = ": " + woodCount.ToString();
    }

    private void Update()
    {
        time += Time.deltaTime;
        timer.text = "Time: " + (int)(time);
    }


    public void addWood()
    {
        woodCount++;
        woodText.text = ": " + woodCount.ToString() ;
    }

    

}

