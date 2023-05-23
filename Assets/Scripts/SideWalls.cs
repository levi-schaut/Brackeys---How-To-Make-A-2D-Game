using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
    private AudioSource collisionSound;

    private void Start() {
        collisionSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Ball") {
            collisionSound.Play();
            string wallName = transform.name;
            GameManager.Score(wallName);
            collision.gameObject.SendMessage("ResetBall");
        }
    }
}