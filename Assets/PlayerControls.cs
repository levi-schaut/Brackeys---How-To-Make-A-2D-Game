using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public KeyCode moveUp;
    public KeyCode moveDown;
    public float speed = 10;

    private Rigidbody2D rb;

    // Start is called once at the start of the game
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(Input.GetKey(moveUp) || Input.GetKey(moveDown))) {
            rb.velocity = new Vector2(0, 0);
        } else {
            if (Input.GetKey(moveUp))
                rb.velocity = new Vector2(0, speed);
            if (Input.GetKey(moveDown))
                rb.velocity = new Vector2(0, -speed);
        }
    }
}
