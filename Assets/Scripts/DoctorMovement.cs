using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorMovement : MonoBehaviour
{
    
    private Animator Animator;
    
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void TransformAdvance()
    {
        if (Animator.GetBool("muting")) Animator.SetBool("monster", true);
        else Animator.SetBool("muting", true);
    }

    public void TransformRegression()
    {
        if (Animator.GetBool("monster")) Animator.SetBool("monster", false);
        else Animator.SetBool("muting", false);
    }

    public bool IsMonster()
    {
        return Animator.GetBool("monster") && Animator.GetBool("muting");
    }

    public bool IsMuting()
    {
        return !Animator.GetBool("monster") && Animator.GetBool("muting");
    }

    public bool IsNormal()
    {
        return !Animator.GetBool("monster") && !Animator.GetBool("muting");
    }
}
