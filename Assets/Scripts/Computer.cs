using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public float moveSpeed = 8.0f;
    public float topBounds = 16.6f;
    public float bottomBounds = -14.4f;

    public GameObject ball;
    private Vector2 ballPosition;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
            if (!ball)
            {
                ball = GameObject.FindGameObjectWithTag("Ball");
            }

                ballPosition = ball.transform.localPosition;

        if (ballPosition.y > this.gameObject.transform.position.y)
        {
            Vector2 pos = this.gameObject.transform.position;
            pos.y += moveSpeed * Time.deltaTime;
            this.gameObject.transform.position = pos;
        } else
        {
            Vector2 pos = this.gameObject.transform.position;
            pos.y -= moveSpeed * Time.deltaTime;
            this.gameObject.transform.position = pos;
        }
    }
}
