using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1 : MonoBehaviour
{
    public GameObject tip;
    private void Start()
    {
        tip.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Role")
        {
            GameManager.trigger1[int.Parse(gameObject.name.Substring(gameObject.name.Length - 1))] = true;
            tip.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Role") tip.SetActive(false);
    }
}
