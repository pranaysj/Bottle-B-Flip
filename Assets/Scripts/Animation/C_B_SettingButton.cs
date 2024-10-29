using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_B_SettingButton : MonoBehaviour
{

    public Animator animator;
    public int press;
    public C_B_Bar bar;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PressButton()
    {
        if (press == 2)
        {
            press = 0;
        }

        press++;

        if (press == 1)
        {
            animator.SetInteger("Setting",1);
            bar.Prees();
        }

        if (press == 2)
        {
            animator.SetInteger("Setting", 2);
            bar.Prees();
            press = 0;
        }
    }

}
