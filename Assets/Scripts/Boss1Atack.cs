using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Atack : StateMachineBehaviour
{
    Transform player;
    public GameObject projectile;
    private Vector2 lpos;
    public GameObject boss;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       
       
       animator.SetTrigger("Idle");
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    // override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
       
       
    // }
 
    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("Idle");
    }

}
