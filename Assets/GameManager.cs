using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GUISkin skin;
    public Transform ball;

    private static int playerScore01 = 0;
    private static int playerScore02 = 0;

    // Update is called once per frame
    public static void Score(string wallName)
    {
        if (wallName == "Right Wall") {
            playerScore01++;
        } else if (wallName == "Left Wall") {
            playerScore02++;
        }
    }

    private void OnGUI() {
        GUI.skin = skin;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 18, 20, 100, 100), playerScore01.ToString());
        GUI.Label(new Rect(Screen.width / 2 + 150 - 18, 20, 100, 100), playerScore02.ToString());

        if (GUI.Button(new Rect(Screen.width/2-121/2, 35, 121, 53), "Reset")) {
            playerScore01 = 0;
            playerScore02 = 0;
            ball.SendMessage("ResetBall");
        }
    }
}
