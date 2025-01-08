using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorCnt : MonoBehaviour
{
    CharacterController charaCnt;
    Animator animator;
    Vector3 moveDirection = Vector3.zero;

    float moveX;
    float moveY;
    float moveZ;

    // Start is called before the first frame update
    void Start()
    {
        charaCnt = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        if (moveX != 0 || moveZ != 0)
        {
            animator.SetBool("Run", true);
            if (moveZ < 0)
            {
                animator.SetBool("BackRun", true);
            }
            else
            {
                animator.SetBool("BackRun", false);
            }
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("Jump");
        }

        //重力検査用
        //moveY -= (9.0f * Time.deltaTime);

        //if (charaCnt.isGrounded)
        //{
        //    moveY = 0.0f;
        //}

        //charaCnt.Move(new Vector3(0, moveY, 0));
    }
}
