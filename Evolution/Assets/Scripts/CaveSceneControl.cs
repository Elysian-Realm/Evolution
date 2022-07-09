using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaveSceneControl : MonoBehaviour
{
    public GameObject role;
    public GameObject goal;

    public GameObject dialog_1;
    public GameObject dialog_2;
    public GameObject dialog_3;
   
    public GameObject image_1;
    public GameObject image_2;

    InputField inputField;
    private string input;

    public void OnCollisionEnter(Collision collision)
    {
      if(collision.collider.name=="Role") dialog_1.SetActive(true);
    }

    public void End_Value(string str)
    {
        input = str;
    }

    public void OnClickAccept()
    {
        input = inputField.text;
        if (input == "") return;
        else if (input == "10")
        {
            dialog_1.SetActive(false);
            dialog_2.SetActive(true);
            image_1.SetActive(false);
            image_2.SetActive(true);
            if (GameManager.robotKilledNumber[1] + GameManager.robotKilledNumber[2] + GameManager.robotKilledNumber[3] <= 5) Invoke("LoadVictoryScene", 5.0f);
            else Invoke("LoadFailureScene", 5.0f);
        }
        else
        {
            dialog_1.SetActive(false);
            dialog_3.SetActive(true);
        }
    }

    public void HideDialog_1()
    {
        dialog_1.SetActive(false);
    }

    public void HideDialog_3()
    {
        dialog_3.SetActive(false);
    }

    public void LoadVictoryScene()
    {
        SceneManager.LoadScene("Victory");
    }

    public void LoadFailureScene()
    {
        SceneManager.LoadScene("Failure");
    }

    // Start is called before the first frame update
    void Start()
    {
        dialog_1.SetActive(false);
        dialog_2.SetActive(false);
        dialog_3.SetActive(false);

        image_2.SetActive(false);

        inputField = dialog_1.GetComponentInChildren<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
