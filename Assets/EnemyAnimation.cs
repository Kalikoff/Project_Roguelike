using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    private bool isWalk;
    private bool isAttack;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isWalk)
        {
            animator.SetBool("isWalk", true);
            animator.SetBool("isAttack", false);
        }

        if (isAttack)
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isAttack", true);
        }
    }

    public void isWalkSet(bool status)
    {
        isWalk = status;
    }

    public void isAttackSet(bool status)
    {
        isAttack = status;
    }
}
