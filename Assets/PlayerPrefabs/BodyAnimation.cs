using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAnimation : MonoBehaviour
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
            animator.SetBool("Body_Move", true);
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Body_Shoot", true);
        }
        else
        {
            animator.SetBool("Body_Move", false);
            animator.SetBool("Body_Shoot", false);
        }
    }
}