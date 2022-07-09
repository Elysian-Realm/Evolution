using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsControl : MonoBehaviour
{
 
    public GameObject panel;
    public GameObject role;

   // bool view = false;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(System.Math.Abs(transform.position.x-role.transform.position.x)<1&& System.Math.Abs(transform.position.y - role.transform.position.y) < 1)
        {
            panel.SetActive(true);
            Destroy(panel, 2.0f);
            Destroy(gameObject, 2.0f);
        }
    }
}
