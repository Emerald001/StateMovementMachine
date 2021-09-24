using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : PlayerState
{
    private Rigidbody Player { get; }

    public int speed;
    public int jumpHeight;

    public GroundedState(StateMachine<PlayerStateManager> _owner, Rigidbody player, int speed, int jumpheight) : base(_owner) {
        Player = player;
        this.speed = speed;
        this.jumpHeight = jumpheight;
    }

    public override void OnEnter()
    {
        Debug.Log("First State");
    }

    public override void OnUpdate()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        base.OnUpdate();
    }

    public void Movement()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        Player.AddForce(new Vector3(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime));
    }

    public void Jump()
    {
        Player.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);

        stateMachine.SwitchState(typeof(AirbornState));
    }
}
