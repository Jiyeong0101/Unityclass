using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float moveDistance = 5f;

    private Vector2 startPos;
    private bool movingUp = true;

    void Start()
    {
        startPos = transform.position; 
    }

    void Update()
    {
        if (movingUp)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            if (transform.position.y >= startPos.y + moveDistance)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            if (transform.position.y <= startPos.y - moveDistance)
            {
                movingUp = true;
            }
        }
    }
}
