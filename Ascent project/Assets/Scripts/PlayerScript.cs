using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private float Horizontal;
    public float speed = 8f;
    private float jumpingpower = 16f;
    private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Animator playerAnimation;

    Vector2 movement;

    // public static int healthpoints;
    //  public Text healthtext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeDirection();
        Horizontal = Input.GetAxisRaw("Horizontal");
        Debug.Log("Horizontal"+ Horizontal);

        if(Horizontal !=0)
        {
            playerAnimation.SetTrigger("WalkTrigger");
        }

        else
        {
            playerAnimation.SetTrigger("IdleTrigger");
        }

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingpower);
        }

        // healthtext.text = "Health: " + healthpoints;

        if (movement.x < 0 && isFacingRight)
        {

            GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (movement.x > 0 && !isFacingRight)
        {

            GetComponent<SpriteRenderer>().flipX = false;

        }   
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Horizontal * speed, rb.velocity.y);
    }

    /* private void Flip()
     {
         if(Horizontal<0)
         {
             Vector2 PlayerscaleX = transform.localScale;
             PlayerscaleX.x *= -1;
             transform.localScale = PlayerscaleX;
         }

         else
         {
             Vector2 PlayerscaleX = transform.localScale;
             PlayerscaleX.x *= 1;
             transform.localScale = PlayerscaleX;
         }
     }*/

    //Update where the player is facing accordingly
    void changeDirection()
    {
        if (Input.GetAxis("Horizontal") > 0.05)
        {
            transform.localScale = new Vector2(3, 3);
        }
        else if (Input.GetAxis("Horizontal") < -0.05)
        {
            transform.localScale = new Vector2(-3, 3);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Outofbounds")
        {
            SceneManager.LoadScene("LoseScene");
        }

        if (collision.gameObject.tag == "Healthpacks")
        {
            Destroy(collision.gameObject);

            //Health.healthpoints += 10;
        }

        if (collision.transform.tag == "GameWinConsole")
        {
            SceneManager.LoadScene("WinScene");
        }

        if (collision.transform.tag == "LevelProgressConsole")
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}
