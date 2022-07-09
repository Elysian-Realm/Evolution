using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFloor3 : MonoBehaviour
{
    public GameObject stairs2;
    public GameObject panel2;

    // Start is called before the first frame update
    void Start()
    {
        stairs2.SetActive(false);
        panel2.SetActive(false);
    }

    public void OnEnterFloor2_Stair()
    {
        if (GameManager.trigger2[1] && GameManager.trigger2[2] && GameManager.trigger2[3])
        {
            stairs2.SetActive(true);
            Invoke("OnEnterFloor3_Hall", 2.0f);
        }
        else
        {
            panel2.SetActive(true);
            Invoke("is_Looked", 2.0f);
        }
    }

    public void OnEnterFloor3_Hall()
    {
        GameManager.level = 3;
        GameManager.room = 0;
        SceneManager.LoadScene("Floor3_Hall");
    }

    public void is_Looked()
    {
        panel2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
