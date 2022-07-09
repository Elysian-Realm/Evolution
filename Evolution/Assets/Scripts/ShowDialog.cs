using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialog : MonoBehaviour
{
    public GameObject Dialog;

    public void PopDialog()
    {
        Dialog.SetActive(true);
    }

    public void HideDialog()
    {
        Dialog.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Dialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
