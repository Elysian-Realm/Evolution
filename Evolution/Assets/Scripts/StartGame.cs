using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void OnStartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void OnEnterGame()
    {
        GameManager.level = 1;
        GameManager.room = 0;
        //SceneManager.LoadScene("Floor1_Hall");
        SceneManager.LoadScene("Background_Intro");
    }

    public void OnEnterRoom1_1()
    {
        GameManager.level = 1;
        GameManager.room = 1;
        SceneManager.LoadScene("Floor1_Room1");
    }

    public void OnEnterRoom1_2()
    {
        GameManager.level = 1;
        GameManager.room = 2;
        SceneManager.LoadScene("Floor1_Room2");
    }

    public void OnEnterFloor1_stair()
    {
        if (GameManager.trigger1[1] && GameManager.trigger1[2] && GameManager.trigger1[3])
            SceneManager.LoadScene("Floor1ToFloor2");
    }

    public void OnReturnHome()
    {
        GameManager.Restart();
        SceneManager.LoadScene("Home");
    }

    public void OnEnterTeach()
    {
        SceneManager.LoadScene("Teach");
    }

    public void OnEnterFloor2_1()
    {
        GameManager.level = 2;
        GameManager.room = 1;
        SceneManager.LoadScene("Floor2_Room1");
    }

    public void OnEnterFloor2_2()
    {
        GameManager.level = 2;
        GameManager.room = 2;
        SceneManager.LoadScene("Floor2_Room2");
    }

    public void OnEnterFloor2_3()
    {
        GameManager.level = 2;
        GameManager.room = 3;
        SceneManager.LoadScene("Floor2_Room3");
    }

    public void OnEnterFloor2_stair()
    {
        if (GameManager.trigger2[1] && GameManager.trigger2[2] && GameManager.trigger2[3])
            SceneManager.LoadScene("Floor2ToFloor3");
    }

    public void OnEnterFloor3_1()
    {
        GameManager.level = 3;
        GameManager.room = 1;
        SceneManager.LoadScene("Floor3_Room1");
    }

    public void OnEnterFloor3_2()
    {
        GameManager.level = 3;
        GameManager.room = 2;
        SceneManager.LoadScene("Floor3_Room2");
    }

    public void OnEnterFloor3_3()
    {
        GameManager.level = 3;
        GameManager.room = 3;
        SceneManager.LoadScene("Floor3_Room3");
    }

    public void OnEnterVictory()
    {
        SceneManager.LoadScene("Victory");
    }

    public void OnEnterFailure()
    {
        SceneManager.LoadScene("Failure");
    }

    public void OnEnterFloor1_Hall()
    {
        GameManager.level = 1;
        GameManager.room = 0;
        SceneManager.LoadScene("Floor1_Hall");
    }

    public void OnEnterFloor2_Hall()
    {
        GameManager.level = 2;
        GameManager.room = 0;
        SceneManager.LoadScene("Floor2_Hall");
    }

    public void OnEnterFloor3_Hall()
    {
        GameManager.level = 3;
        GameManager.room = 0;
        SceneManager.LoadScene("Floor3_Hall");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Dead()
    {
        if (GameManager.level == 1) SceneManager.LoadScene("Floor1_Hall");
        if (GameManager.level == 2) SceneManager.LoadScene("Floor2_Hall");
        if (GameManager.level == 3) SceneManager.LoadScene("Floor3_Hall");
        GameManager.Replay();
    }
}
