using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeLogic : MonoBehaviour
{
    public int health = 3;
    public float chopTimer = 0.5f;
    private Animator anim;
    private new AudioSource audio;
    public AudioClip chopSFX;
    public bool canChop = false;
    private bool chopped = false;
    public CircleCollider2D range;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!chopped)
        {
            if (health <= 0)
            {
                chopped = true;
                anim.SetBool("Chopped", true);
                range.enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                GameManager.Instance.addWood();
                ShopManager.Instance.money += 2;
                ShopManager.Instance.UpdateMoney();
            }
            if (canChop && Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Chop());
            }
        }
    }

    public IEnumerator Chop()
    {
        canChop = false;
        audio.PlayOneShot(chopSFX);
        health -= ShopManager.Instance.axeDamage;
        
        anim.SetTrigger("Chop");
        yield return new WaitForSeconds(chopTimer);
        canChop = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canChop = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canChop = false;
        }
    }
}
