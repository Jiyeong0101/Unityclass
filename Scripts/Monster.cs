using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 3f; // 이동 속도
    public float moveRange = 5f; // 이동 범위

    private Rigidbody2D rb2d;
    private bool movingRight = true; // 처음에 오른쪽으로 움직임
    private float startPos ; // 몬스터의 시작 위치

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startPos = transform.position.x;
    }

    void Update()
    {
        
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

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.tag == "Bullet")
        {
            Destroy(gameObject);
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
