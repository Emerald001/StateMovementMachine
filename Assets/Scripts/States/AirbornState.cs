using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirbornState : PlayerState
{
    public AirbornState(StateMachine<PlayerStateManager> _owner) : base(_owner)
    {
        
    }

    public override void OnEnter()
    {
        Debug.Log("Second State");
    }

    public override void OnUpdate()
    {
        SaySomthing();
        base.OnUpdate();
    }

    public void SaySomthing()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("In the Airborn State, Doing things");
        }
    }
}
