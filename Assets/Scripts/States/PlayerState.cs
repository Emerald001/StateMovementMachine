using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State<PlayerStateManager>
{
    public PlayerState(StateMachine<PlayerStateManager> stateMachine) : base(stateMachine) { }

    public override void OnEnter()
    {

    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        foreach (Transition<PlayerStateManager> transition in transitions)
        {
            if (transition.condition.Invoke(stateMachine.Controller))
            {
                Debug.Log("Change State");

                stateMachine.SwitchState(transition.toState);
                return;
            }
        }
    }
}
