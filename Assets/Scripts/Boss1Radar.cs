using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Radar : StateMachineBehaviour
{
    public GameObject g1;
    int cc=0;
    public GameObject g2;
    Vector2 pos1;
    Vector2 pos2;
    Vector2 pos3;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       pos1= new Vector2(24,0);
       pos2= new Vector2(26,2);
       pos3= new Vector2(28,-2);
       cc=Random.Range(0, 3);
       if(cc==0)
       {
            Instantiate(g1,pos1,Quaternion.identity);
            Instantiate(g1,pos2,Quaternion.identity);
            Instantiate(g1,pos3,Quaternion.identity);
       }
       else if(cc==1)
       {
            pos1= new Vector2(24, 3);
            Instantiate(g2,pos1,Quaternion.identity);
            pos1= new Vector2(26, 3);
            Instantiate(g2,pos1,Quaternion.identity);
            pos1= new Vector2(28, 3);
            Instantiate(g2,pos1,Quaternion.identity);
            pos1= new Vector2(24, -3);
            Instantiate(g2,pos1,Quaternion.identity);
            pos1= new Vector2(26, -3);
            Instantiate(g2,pos1,Quaternion.identity);
            pos1= new Vector2(28, -3);
            Instantiate(g2,pos1,Quaternion.identity);
       }
       else
       {
        Instantiate(g1,pos1,Quaternion.identity);
        Instantiate(g1,pos2,Quaternion.identity);
        Instantiate(g1,pos3,Quaternion.identity);
       }
        
        Sounds.PlaySound ("bossradar");
        animator.SetTrigger("Idle");
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("Idle");
    }

}
