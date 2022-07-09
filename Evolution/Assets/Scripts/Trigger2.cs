using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2 : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.trigger2[int.Parse(gameObject.name.Substring(gameObject.name.Length - 1))]) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Role")
        {
            GameManager.trigger2[int.Parse(gameObject.name.Substring(gameObject.name.Length - 1))] = true;
            Destroy(gameObject);
        }
    }
}
