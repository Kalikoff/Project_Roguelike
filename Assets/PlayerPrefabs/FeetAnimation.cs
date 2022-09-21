using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetAnimation : MonoBehaviour
{
    public PlayerInfo playerInfo;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInfo.moveHorizontal != 0 || playerInfo.moveVertical != 0)
        {
            animator.SetBool("Feet_Idle", false);
            animator.SetBool("Feet_Walk", true);
            animator.SetBool("Feet_Run", false);
        }
        else
        {
            animator.SetBool("Feet_Idle", true);
            animator.SetBool("Feet_Walk", false);
            animator.SetBool("Feet_Run", false);
        }
    }
}