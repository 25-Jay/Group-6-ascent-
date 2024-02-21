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

    public static int healthpoints;
    public Text healthtext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingpower);
        }

        healthtext.text = "Health: " + healthpoints;

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if(isFacingRight&&Horizontal<0f||!isFacingRight&&Horizontal>0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
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
    }
}
