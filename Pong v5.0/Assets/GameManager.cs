using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int Health = 3;
    public static int PlayerScore = 0;
    public GUISkin layout;
    GameObject theBall;
    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }
    public static void Score(string wallID)
    {
        if(wallID == "BottomWalls")
        {
            Health--;
        }
    }
    
    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "HP : " + Health);
        GUI.Label(new Rect(Screen.width / 2 + 150 - 12, 20, 100, 100), "Score : " + PlayerScore);

        if (GUI.Button(new Rect(Screen.width/2 + 300, 350,100,40),"RESTART"))
        {
            Health = 3;
            PlayerScore = 0;
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
            PlayAgain();
        }
        if(Health == 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 35, 200, 2000, 1000), "YOU LOSE");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        if(PlayerScore== 4)
        {
            GUI.Label(new Rect(Screen.width / 2 - 35, 200, 2000, 1000), "YOU WON");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }

    }
    public void IncrementScore()
    {
        PlayerScore++;
    }
    // Update is called once per frame
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
