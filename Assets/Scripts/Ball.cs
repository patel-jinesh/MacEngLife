using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float speed = 30;
    public float leftScore = 0;
    public float rightScore = 0;
    public Text Score;
    public MinigameController mg;
    public GameObject player;
    public GameObject computer;

    void Start()
    {
        mg = TaskController.mg;
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            mg.SetResult('i');
        }
    }

    float hitFactor(Vector2 ballPosition, Vector2 paddlePosition, float paddleY)
    {
        return (ballPosition.y - paddlePosition.y) / paddleY;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Left Paddle")
        {
            float y = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Debug.Log(y);
            Vector2 direction = new Vector2(1,y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }

        if (collision.gameObject.name == "Right Paddle")
        {
            float y = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 direction = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }

        if (gameObject.transform.position.x < player.transform.position.x)
        {
            mg.SetResult('f');
        } else if (gameObject.transform.position.x > computer.transform.position.x) {
            mg.SetResult('c');
        }
    }
}