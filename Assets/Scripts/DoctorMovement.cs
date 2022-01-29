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
        Debug.Log("muting: " + Animator.GetBool("muting") + " monster: " +  Animator.GetBool("monster"));
    }

    public void TransformRegression()
    {
        if (Animator.GetBool("monster")) Animator.SetBool("monster", false);
        else Animator.SetBool("muting", false);
        Debug.Log("muting: " + Animator.GetBool("muting") + " monster: " +  Animator.GetBool("monster"));
    }
}
