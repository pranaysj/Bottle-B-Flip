using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_B_Bar : MonoBehaviour
{
    public Animator animator;
    public C_B_SettingButton bar;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //bar = GetComponent<C_B_SettingButton>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (bar.press == 0)
    //    {
    //        animator.SetInteger("Bar", 0);
    //    }
    //    if (bar.press == 1 )
    //    {
    //        animator.SetInteger("Bar",1);
    //    }
    //    if (bar.press == 2  )
    //    {
    //        animator.SetInteger("Bar", 2);
    //    }
    //}

    public void Prees()
    {
        if (bar.press == 0)
        {
            animator.SetInteger("Bar", 0);
        }
        if (bar.press == 1)
        {
            animator.SetInteger("Bar", 1);
        }
        if (bar.press == 2)
        {
            animator.SetInteger("Bar", 2);
        }
    }
}
