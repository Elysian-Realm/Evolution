using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCave : MonoBehaviour
{
    public GameObject panel3;

    // Start is called before the first frame update
    void Start()
    {
        panel3.SetActive(false);
    }

    public void is_Looked()
    {
        panel3.SetActive(false);
    }
    public void OnEnterPasswordpage()
    {
        if (GameManager.mechaNumber[3, 0] == 0 && GameManager.mechaNumber[3, 1] == 0 && GameManager.mechaNumber[3, 2] == 0 && GameManager.mechaNumber[3, 3] == 0)
            SceneManager.LoadScene("Cave");
        else
        {
            panel3.SetActive(true);
            Invoke("is_Looked", 2.0f);
        }
    }
}
