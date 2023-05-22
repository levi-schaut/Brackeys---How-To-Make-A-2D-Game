using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float ballSpeed = 100f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Launches the ball after 2 seconds
        Invoke("LaunchBall", 2f);
    }

    // Reset the position and velocity of the ball before launching it again.
    void ResetBall() {
        rb.velocity = new Vector2(0f, 0f);
        transform.position = new Vector2(0f, 0f);
        Invoke("LaunchBall", 0.5f);
    }

    // Launch the ball in a random direction.
    void LaunchBall() {
        float randNum = Random.Range(0f, 1f);
        if (randNum <= 0.5) {
            rb.AddForce(new Vector2(-ballSpeed, 10));
        } else {
            rb.AddForce(new Vector2(ballSpeed, 10));
        }
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player") {
            Vector2 ballVel = rb.velocity;
            Vector2 playVel = collision.collider.attachedRigidbody.velocity;
            rb.velocity = new Vector2(ballVel.x, ballVel.y / 2 + playVel.y / 2);
        }
    }
}
