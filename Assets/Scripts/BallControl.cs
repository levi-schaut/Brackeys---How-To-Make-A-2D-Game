using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float ballSpeed = 100f;
    public float launchDelay = 1f;

    private Rigidbody2D rb;
    private AudioSource click;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        click = GetComponent<AudioSource>();

        // Launches the ball after 2 seconds
        Invoke("LaunchBall", launchDelay + 1f);
    }

    // Reset the position and velocity of the ball before launching it again.
    void ResetBall() 
    {
        rb.velocity = new Vector2(0f, 0f);
        transform.position = new Vector2(0f, 0f);
        Invoke("LaunchBall", launchDelay);
    }

    // Launch the ball in a random direction.
    void LaunchBall() 
    {
        float randNum = Random.Range(0f, 1f);
        if (randNum <= 0.5) {
            rb.AddForce(new Vector2(-ballSpeed, 10));
        } else {
            rb.AddForce(new Vector2(ballSpeed, 10));
        }
    }

    // Update is called once per frame
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player") 
        {
            // Capture the initial velocities of both objects
            Vector2 ballVel = rb.velocity;
            Vector2 playVel = collision.collider.attachedRigidbody.velocity;

            // Correct the y-velocity of the ball
            ballVel.y = ballVel.y / 2 + playVel.y / 2;

            // Correct the x-velocity, if needed
            if (ballVel.x < 18 && ballVel.x > 0) {
                ballVel.x = 20;
            } else if (ballVel.x > -18 && ballVel.x < 0) {
                ballVel.x = -20;
            }

            // Set the ball's new velocity to the corrected velocity
            rb.velocity = ballVel;

            // Play the "click" sound effect with a random pitch
            click.pitch = Random.Range(0.9f, 1.1f);
            click.Play();
        }
    }
}
