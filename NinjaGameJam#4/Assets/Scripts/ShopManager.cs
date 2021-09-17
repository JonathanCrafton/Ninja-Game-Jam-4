using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public int money = 10;
    public Text moneyCount;

    public float playerSpeed = 5.0f;
    public Text speedText;
    public int speedCost = 10;
    public Text speedPrice;

    public int axeDamage = 1;
    public Text axeText;
    public int axeCost = 20;
    public Text axePrice;

    public Text winText;
    public int winCost = 100;
    
    public static ShopManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

    }

    public void ResetShop()
    {
        axeCost = 20;
        axeDamage = 1;
        axePrice.text = "Price: " + axeCost;
        axeText.text = "Axe Damage: " + axeDamage;

        speedCost = 10;
        playerSpeed = 5.0f;
        speedPrice.text = "Price: " + speedCost;
        speedText.text = "Speed: " + playerSpeed;

        money = 0;
        moneyCount.text = ": " + money;
    }

    public void Update()
    {
        if(SceneManager.GetActiveScene().name == "Shop")
        {
            gameObject.GetComponentInChildren<Canvas>().enabled = true;
        }
        else
            gameObject.GetComponentInChildren<Canvas>().enabled = false;
    }

    public void AddSpeed()
    {
        if(money >= speedCost)
        {
            money -= speedCost;
            speedCost += 5;
            playerSpeed += 0.5f;
            UpdateMoney();
            speedPrice.text = "Price: " + speedCost;
            speedText.text = "Speed: " + playerSpeed;
        }
    }

    public void UpgradeAxe()
    {
        if (money >= axeCost)
        {
            money -= axeCost;
            axeCost += 10;
            axeDamage++;
            UpdateMoney();
            axePrice.text = "Price: " + axeCost;
            axeText.text = "Axe Damage: " + axeDamage;
        }
    }

    public void BuyWin()
    {
        if (money >= winCost)
        {
            ShopManager.Instance.GetComponentInChildren<Canvas>().enabled = false;
            SceneManager.LoadScene("Win", LoadSceneMode.Single);
        }
    }

    public void UpdateMoney()
    {
        moneyCount.text = ": " + money;
    }
    



}
