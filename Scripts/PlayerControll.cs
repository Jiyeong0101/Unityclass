using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour
{
    
    public float maxSpeed = 6f;
    public float jumpForce = 500f;

    [HideInInspector]
    public bool lookingRight = true;

    private Rigidbody2D rb2d;
    private Animator anim;

    private bool isGrounded = true;
    private int jumpCount = 0;

    public GameObject BulletPrefab;
    public GameObject canvas;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
            Debug.Log("Å¬¸¯");
        }

        float hor = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(hor * maxSpeed, rb2d.velocity.y);

        if ((hor > 0 && !lookingRight) || (hor < 0 && lookingRight))
            Flip();

        if (Input.GetButtonDown("Jump") && jumpCount < 2)
        {
            jumpCount++; 
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, jumpForce));
        }

        else if(Input.GetButtonDown("Jump") && rb2d.velocity.y > 0)
        {
            rb2d.velocity *= 0.5f;
        }

        anim.SetBool("IsGround", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.3f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    public void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 myScale = transform.localScale;
        myScale.x *= -1;
        transform.localScale = myScale;
    }

    private void FireBullet()
    {
        if (BulletPrefab != null)
        {
            GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRb2d = bullet.GetComponent<Rigidbody2D>();
        }
    }

    private void Die()
    {
        rb2d.velocity = Vector2.zero;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.tag == "Monster")
        {
            Die();
            canvas. SetActive(true);
        }

        if (collison.tag == "Platform")
        {
            Die();
            canvas.SetActive(true);
        }

        if (collison.tag == "Door1")
        {
            SceneManager.LoadScene("Stage2");
        }
        if (collison.tag == "Door2")
        {
            SceneManager.LoadScene("Stage3");
        }
        if (collison.tag == "Door3")
        {
            SceneManager.LoadScene("Stage4");
        }
        if (collison.tag == "Door4")
        {
            SceneManager.LoadScene("Stage5");
        }
        if (collison.tag == "Door5")
        {
            SceneManager.LoadScene("Ending");
        }

    }
}
