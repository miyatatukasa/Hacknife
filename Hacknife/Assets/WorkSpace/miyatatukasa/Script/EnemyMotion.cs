using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour
{
    Animator anim;
    private Animator animator;
    private string currentStateName;


    void GetCurrentAnimationStateName()
    {
        animator = GetComponent<Animator>();
        //State�̎擾
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            currentStateName = "idle";
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            currentStateName = "walk";
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            currentStateName = "run";
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Hack"))
        {
            currentStateName = "Hack";
        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (XboxInput.XBXInput.Push(XboxInput.XBXBtn.B))
        {
            anim.Play("Hack");
        }

        if (XboxInput.XBXInput.Push(XboxInput.XBXBtn.Lstick))
        {
            anim.Play("Walk");
        }
    }
}
