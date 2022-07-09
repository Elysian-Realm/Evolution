using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Floor3SceneControl : MonoBehaviour
{
    public GameObject role;
    public GameObject goal;
    public Slider heath;

    void Update()
    {
        if (GameManager.mechaNumber[GameManager.level, GameManager.room] == 0 && System.Math.Abs(role.transform.position.x - goal.transform.position.x) < 1 && System.Math.Abs(role.transform.position.y - goal.transform.position.y) < 1 || heath.value <= 0)
        {
            if (heath.value <= 0) SceneManager.LoadScene("BleedFailure");
            else
            {
                GameManager.level = 3;
                GameManager.room = 0;
                SceneManager.LoadScene("Floor3_Hall");
            }
        }
    }
}
