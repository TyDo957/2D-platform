using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRun : StateMachineBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Transform player;
    Boss boss;
   
    public float atackrange;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LoolAtPlayer();
        Vector2 taget = new Vector2 (player.position.x , rb.position.y);
        Vector2 newpos = Vector2.MoveTowards(rb.position, taget, speed * Time.fixedDeltaTime) ;
        rb.MovePosition(newpos);
        if (Vector2.Distance(player.position, rb.position) <= atackrange)
        {
            animator.SetTrigger("Atack");
            
        }

        
       

        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Atack");
    }
}
