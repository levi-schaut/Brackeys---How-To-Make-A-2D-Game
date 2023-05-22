using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float randNum = Random.Range(0f, 1f);
        if (randNum <= 0.5) {
            rb.AddForce(new Vector2(-80, 10));
        } else {
            rb.AddForce(new Vector2(80, 10));
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
