using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform ball;
    public Text leftScoreText;
    public Text rightScoreText;

    public static int playerScore01 = 0;
    public static int playerScore02 = 0;

    // Update is called once per frame
    private void Update()
    {
        leftScoreText.text = playerScore01.ToString();
        rightScoreText.text = playerScore02.ToString();
    }

    public static void Score(string wallTag)
    {
        if (wallTag == "RightWall") {
            playerScore01++;
        } else if (wallTag == "LeftWall") {
            playerScore02++;
        }
    }

    public void ResetScore()
    {
        playerScore01 = 0;
        playerScore02 = 0;
    }
}
