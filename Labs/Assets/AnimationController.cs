using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    Animator animator;
    PlayerBehaviour playerBehaviour;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerBehaviour = FindObjectOfType<PlayerBehaviour>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    animator.SetInteger("AnimationState", 0);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    animator.SetInteger("AnimationState", 1);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    animator.SetInteger("AnimationState", 2);
        //}

        if (Vector3.Distance(transform.position, playerBehaviour.transform.position) < 2)
        {
            animator.SetInteger("AnimationState", 2);
            transform.LookAt(new Vector3(playerBehaviour.transform.position.x, transform.position.y, playerBehaviour.transform.position.z));
        }
        else
        {
            animator.SetInteger("AnimationState", 1);
        }
    }
}
