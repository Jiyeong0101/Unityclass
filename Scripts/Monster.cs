using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 3f; // �̵� �ӵ�
    public float moveRange = 5f; // �̵� ����

    private Rigidbody2D rb2d;
    private bool movingRight = true; // ó���� ���������� ������
    private float startPos ; // ������ ���� ��ġ

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
