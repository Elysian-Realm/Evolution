using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFloor2 : MonoBehaviour
{
    public GameObject stairs1;
    public GameObject panel1;

    // Start is called before the first frame update
    void Start()
    {
        stairs1.SetActive(false);
        panel1.SetActive(false);
    }

    public void OnEnterFloor1_Stair()
    {
        if (GameManager.trigger1[1] && GameManager.trigger1[2] && GameManager.trigger1[3])
        {
            stairs1.SetActive(true);
            Invoke("OnEnterFloor2_Hall", 2.0f);
        }
        else
        {
            panel1.SetActive(true);
            Invoke("is_Looked", 2.0f);
        }
    }

    public void OnEnterFloor2_Hall()
    {
        GameManager.level = 2;
        GameManager.room = 0;
        SceneManager.LoadScene("Floor2_Hall");
    }

    public void is_Looked()
    {
        panel1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
