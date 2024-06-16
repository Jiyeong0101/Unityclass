using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform2 : MonoBehaviour
{
    public float moveSpeed = 3f; 
    public float moveRange = 5f; 

    private Rigidbody2D rb2d;
    private bool movingRight = true; 
    private float startPos; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startPos = transform.position.x; 
    }

    void Update()
    {
        // 몬스터 이동
        if (movingRight)
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }

        if (transform.position.x >= startPos + moveRange && movingRight)
        {
            Flip();
        }
        else if (transform.position.x <= startPos - moveRange && !movingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
