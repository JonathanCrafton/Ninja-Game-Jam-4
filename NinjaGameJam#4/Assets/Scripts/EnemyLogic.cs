using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public float enemySpeed = 4.0f;

    //public GameObject player;
    private GameObject target = null;
    private GameObject temp = null;
    private float distance = 0.0f;


    void Update()
    {
        /*distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance <= 100.0f)
        {
            //StartCoroutine(TargetPlayer());
        }
        */
        if(target != null)
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            temp = collision.gameObject;
            StartCoroutine(TargetPlayer());
        }
    }

    IEnumerator TargetPlayer()
    {
        yield return new WaitForSeconds(5);
        target = temp;
    }
}
