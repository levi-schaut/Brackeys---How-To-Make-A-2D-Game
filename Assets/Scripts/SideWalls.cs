using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
    public AudioSource scoreSound;
    public BallControl ball;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Ball") {
            scoreSound.Play();
            string wallTag = transform.tag;
            GameManager.Score(wallTag);

            string launchDirection;
            if (wallTag == "LeftWall") {
                launchDirection = "Right";
            } else {
                launchDirection = "Left";
            }
            ball.ResetBall(launchDirection);
        }
    }
}
