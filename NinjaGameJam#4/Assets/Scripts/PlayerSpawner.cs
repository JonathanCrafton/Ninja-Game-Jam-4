using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        GameObject.Instantiate(player, transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.Instance.time >= 20)
        {
            if(collision.tag == "Player")
            {
                SceneManager.LoadScene("Shop", LoadSceneMode.Single);
                ShopManager.Instance.GetComponentInChildren<Canvas>().enabled = true;
            }
        }
    }
}
