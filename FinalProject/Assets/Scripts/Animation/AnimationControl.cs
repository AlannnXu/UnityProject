using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public AudioSource runSound;
    public AudioSource jumpSound;
    public AudioSource throwSound;
    public AudioSource deathSound;
    public Player player;
    public Animator animator;
    private bool isIdle = true;
    private int isRunning = 0;//0 静止 1 左 2 右
    private bool isJumping = false;
    private bool exBall = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //移动跳跃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(player.isOnGround)
            {
                if (isRunning > 0)
                {
                    animator.Update(0);
                    animator.Play("5_Skill_Magic");
                    isIdle = false;
                    isJumping = true;
                }
                else
                {
                    animator.Update(0);
                    animator.Play("5_Skill_Magic");
                    isIdle = false;
                    isJumping = true;
                }
            }
        }else if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) && isRunning == 0)
        {
            animator.SetBool("IdleToRun", true);
            isIdle=false;
            isRunning = 1;
        }else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) && isRunning == 0)
        {
            animator.SetBool("IdleToRun", true);
            isIdle = false;
            isRunning = 2;
        }

        ResetAnimator();

        //扔球
        if (Input.GetKeyDown(KeyCode.L)&&(GameObject.Find("thunderBall(Clone)") == null)){
            Debug.Log("asdada");
            animator.Update(0);
            animator.Play("2_Attack_Normal");
        }
    }

    private void ResetAnimator()
    {
 
        if(Input.GetKeyUp(KeyCode.A)&& isRunning == 1)
        {
            animator.SetBool("IdleToRun", false);
            animator.Play("0_idle");
            isIdle = true;
            isRunning = 0;
        }else if(Input.GetKeyUp(KeyCode.D) && isRunning == 2)
        {
            animator.SetBool("IdleToRun", false);
            animator.Play("0_idle");
            isIdle = true;
            isRunning = 0;
        }else if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            isIdle = true;
            isRunning = 0;
        }     
        else if(isJumping == true && player.isOnGround)
        {
            animator.SetBool("IdleToJump",false);
            animator.SetBool("RunToJump", false);
            animator.SetBool("JumpToJump", false);
            animator.Update(0f);
            isIdle = true;
            isJumping = false;
        }


    }

}
