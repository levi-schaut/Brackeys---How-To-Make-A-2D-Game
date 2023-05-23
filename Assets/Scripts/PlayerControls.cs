using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public KeyCode moveUp;
    public KeyCode moveDown;
    public float speed = 10;
    public Rigidbody2D playerRigidbody;


    // Update is called once per frame
    void Update()
    {
        if (!(Input.GetKey(moveUp) || Input.GetKey(moveDown))) {
            playerRigidbody.velocity = new Vector2(0, 0);
        } else {
            if (Input.GetKey(moveUp))
                playerRigidbody.velocity = new Vector2(0, speed);
            if (Input.GetKey(moveDown))
                playerRigidbody.velocity = new Vector2(0, -speed);
        }
    }
}
