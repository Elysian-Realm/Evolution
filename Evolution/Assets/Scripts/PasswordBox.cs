using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordBox : MonoBehaviour
{
    public GameObject panel1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Role")
        {
            panel1.SetActive(true);
        }
    }
}
