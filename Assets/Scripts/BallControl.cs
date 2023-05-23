using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float ballSpeed = 100f;
    public float launchDelay = 1f;

    public Rigidbody2D ballRigidbody;
    public AudioSource clickSound;
    private bool ballIsLaunching;


    // Start is called before the first frame update
    void Start()
    {
        // Launches the ball after 2 seconds
        StartCoroutine(WaitToLaunchBall(launchDelay + 1f));
    }

    IEnumerator WaitToLaunchBall(float waitTime, string direction = "Random")
    {
        ballIsLaunching = true;

        yield return new WaitForSeconds(waitTime);
        LaunchBall(direction);

        ballIsLaunching = false;
    }

    // Reset the position and velocity of the ball before launching it again.
    public void ResetBall(string direction = "Random") 
    {
        if (!ballIsLaunching) {
            ballRigidbody.velocity = new Vector2(0f, 0f);
            transform.position = new Vector2(0f, 0f);
            StartCoroutine(WaitToLaunchBall(launchDelay, direction));
        }
    }

    // Launch the ball in a given or random direction.
    void LaunchBall(string direction = "Random") 
    {
        if (direction == "Random") {
            if (Random.Range(0f, 1f) <= 0.5) {
                direction = "Left";
            }
            else {
                direction = "Right";
            }
        }
        float launchAngle = Random.Range(-20f, 20f);
        if (direction == "Left") {
            ballRigidbody.AddForce(new Vector2(-ballSpeed, launchAngle));
        } else {
            ballRigidbody.AddForce(new Vector2(ballSpeed, launchAngle));
        }
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player") 
        {
            // Capture the initial velocities of both objects
            Vector2 ballVel = ballRigidbody.velocity;
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
            ballRigidbody.velocity = ballVel;

            // Play the "click" sound effect with a random pitch
            clickSound.pitch = Random.Range(0.9f, 1.1f);
            clickSound.Play();
        }
    }
}
