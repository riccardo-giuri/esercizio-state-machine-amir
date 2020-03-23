using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armed_state : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log(this);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            GameManager.GMsingleton.Unequipweapon();
        }

        if(GameManager.GMsingleton.pistolabehaviour.canshoot == true && Input.GetMouseButtonDown(0))
        {
            Debug.Log("sto sparando");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.GoToreloadingState();
        }

        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
