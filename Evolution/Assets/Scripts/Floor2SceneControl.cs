using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Floor2SceneControl : MonoBehaviour
{
    public GameObject role;
    public GameObject goal;
    public Slider heath;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.mechaNumber[GameManager.level, GameManager.room] == 0 && System.Math.Abs(role.transform.position.x - goal.transform.position.x) < 1 && System.Math.Abs(role.transform.position.y - goal.transform.position.y) < 1 || heath.value <= 0)
        {
            if (heath.value <= 0) SceneManager.LoadScene("BleedFailure");
            else
            {
                GameManager.level = 2;
                GameManager.room = 0;
                SceneManager.LoadScene("Floor2_Hall");
            }
        }
    }
}
