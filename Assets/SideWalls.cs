using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Ball") {
            string wallName = transform.name;
            GameManager.Score(wallName);
            collision.gameObject.SendMessage("ResetBall");
        }
    }
}
