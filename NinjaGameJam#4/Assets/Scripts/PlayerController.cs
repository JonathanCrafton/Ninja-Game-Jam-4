using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{ 
    private Rigidbody2D rbody;
    private Animator anim;
    private new AudioSource audio;

    public float speed = 5.0f;

    public GameObject pauseMenu;

    private float horizontal;
    private float vertical;

    private bool paused = false;


    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        speed = ShopManager.Instance.playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        anim.SetFloat("V_Horizontal", horizontal);
        anim.SetFloat("V_Vertical", vertical);

        if(horizontal != 0 || vertical != 0)
        {
            if(!audio.isPlaying)
                audio.Play();
        }
        else
        {
            audio.Pause();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }
    void FixedUpdate()
    {
        rbody.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    public void PauseGame()
    {
        paused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log(collision.tag);
            Die();

        }
    }

    public void Die()
    {
        ShopManager.Instance.ResetShop();
        SceneManager.LoadScene("Death", LoadSceneMode.Single);
    }

}
