using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    float timer;

    void Start()
    {
        timer = 0.5f;
    }

    void Update()
    {
        if (timer < 0) Destroy(gameObject);
        timer -= Time.deltaTime;
    }
}
