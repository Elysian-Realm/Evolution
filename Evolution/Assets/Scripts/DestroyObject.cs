using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.5f);//对象三秒后消失
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
