using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BonusControl : MonoBehaviour
{
    public GameObject bonus_panel;
    public GameObject bonus_panel1;
    public GameObject bonus_panel2;
    public GameObject bonus_panel3;
    public GameObject bonus_panel4;
    public GameObject bonus_panel5;
    public GameObject bonus_panel6;
    public GameObject bonus_panel7;
    public GameObject bonus_panel8;
    public GameObject bonus_panel9;
    public GameObject bonus_panel10;

    private float timer;
    private bool move;
    // Start is called before the first frame update
    void Start()
    {
        bonus_panel.SetActive(false);
        bonus_panel1.SetActive(false);
        bonus_panel2.SetActive(false);
        bonus_panel3.SetActive(false);
        bonus_panel4.SetActive(false);
        bonus_panel5.SetActive(false);
        bonus_panel6.SetActive(false);
        bonus_panel7.SetActive(false);
        bonus_panel8.SetActive(false);
        bonus_panel9.SetActive(false);
        bonus_panel10.SetActive(false);
        timer = 0;
        move = false;
    }

    public void ExitBonusPanel()
    {
        bonus_panel.SetActive(false);
        bonus_panel1.SetActive(false);
        bonus_panel2.SetActive(false);
        bonus_panel3.SetActive(false);
        bonus_panel4.SetActive(false);
        bonus_panel5.SetActive(false);
        bonus_panel6.SetActive(false);
        bonus_panel7.SetActive(false);
        bonus_panel8.SetActive(false);
        bonus_panel9.SetActive(false);
        bonus_panel10.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        if (timer >= -0.1f) timer += Time.deltaTime;
        if (Input.anyKeyDown)
            move = true;


        if (move == false)
        {
            if (timer > 30.0f && timer < 32.0f)
            {
                bonus_panel.SetActive(true);
                bonus_panel1.SetActive(true);
            }
            else if (timer > 32.0f && timer < 34.0f)
            {
                bonus_panel2.SetActive(true);
            }
            else if (timer > 34.0f && timer < 36.0f)
            {
                bonus_panel3.SetActive(true);
            }
            else if (timer > 36.0f && timer < 38.0f)
            {
                bonus_panel4.SetActive(true);
            }
            else if (timer > 38.0f && timer < 40.0f)
            {
                bonus_panel5.SetActive(true);
            }
            else if (timer > 40.0f && timer < 42.0f)
            {
                bonus_panel6.SetActive(true);
            }
            else if (timer > 42.0f && timer < 44.0f)
            {
                bonus_panel7.SetActive(true);
            }
            else if (timer > 44.0f && timer < 46.0f)
            {
                bonus_panel8.SetActive(true);
            }
            else if (timer > 46.0f && timer < 48.0f)
            {
                bonus_panel9.SetActive(true);
            }
            else if (timer > 48.0f && timer < 50.0f)
            {
                bonus_panel10.SetActive(true);
            }
            else if (timer > 50.0f)
                timer = -1;
        }


    }
}
