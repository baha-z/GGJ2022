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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Animator.GetBool("muting")) Animator.SetBool("monster", true);
            else Animator.SetBool("muting", true);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (Animator.GetBool("monster")) Animator.SetBool("monster", false);
            else Animator.SetBool("muting", false);

        }
    }

    private void FixedUpdate()
    {
        
    }
}
