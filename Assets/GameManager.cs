using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GUISkin skin;

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
        Debug.Log("Player score 01: " + playerScore01);
        Debug.Log("Player score 02: " + playerScore02);
    }

    private void OnGUI() {
        GUI.skin = skin;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), playerScore01.ToString());
        GUI.Label(new Rect(Screen.width / 2 + 150 - 12, 20, 100, 100), playerScore02.ToString());
    }
}
