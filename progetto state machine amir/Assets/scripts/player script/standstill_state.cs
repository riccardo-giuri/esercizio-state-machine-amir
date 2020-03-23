using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standstill_state : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log(this);
    }

     //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKey(KeyCode.W))
        {
            float timesincelastclick = Time.time - GameManager.GMsingleton.Playerbehaviour.lastclick;

            if (timesincelastclick <= GameManager.GMsingleton.Playerbehaviour.doubleclicktime)
            {
                GameManager.GoTorunningState();
                Debug.Log("sto correndo");
            }
            else
            {
                GameManager.GoTowalkingState();
                Debug.Log("sto camminando");
            }

            GameManager.GMsingleton.Playerbehaviour.lastclick = Time.time;
        }

        if (GameManager.GMsingleton.pistolabehaviour.canshoot == true && Input.GetMouseButtonDown(1))
        {
            GameManager.GMsingleton.pistolabehaviour.Aim();
            GameManager.GoToaimState();
        }

        if(Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.A))
        {
            GameManager.GoTowalkingState();
        }
        
        GameManager.GoTocrouchState();
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
