using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    private StateMachine<PlayerStateManager> coupledStateMachine;
    private TransitionEvaluator transitionEvaluator;

    [Header("Movement Variables")]
    [SerializeField] private int speed = 10;
    [SerializeField] private int jumpHeight = 5;

    //private objects
    protected GameObject player;

    private void Start()
    {
        player = this.gameObject;

        coupledStateMachine = new StateMachine<PlayerStateManager>(this);
        transitionEvaluator = new TransitionEvaluator();

        GroundedState groundedState = new GroundedState(coupledStateMachine, player.GetComponent<Rigidbody>(), speed, jumpHeight);
        coupledStateMachine.AddState(typeof(GroundedState), groundedState);

        AirbornState airbornState = new AirbornState(coupledStateMachine);
        coupledStateMachine.AddState(typeof(AirbornState), airbornState);

        AddTransitionWithBool(groundedState, transitionEvaluator.InTheAir(player), typeof(AirbornState));
        AddTransitionWithKey(groundedState, KeyCode.E, typeof(AirbornState));
        AddTransitionWithBool(airbornState, transitionEvaluator.IsGrounded(player), typeof(GroundedState));

        coupledStateMachine.SwitchState(typeof(GroundedState));
    }

    private void Update()
    {
        coupledStateMachine.RunUpdate();
    }

    //private void FixedUpdate()
    //{
    //    coupledStateMachine.RunUpdate();
    //}

    public void AddTransitionWithKey(State<PlayerStateManager> _state, KeyCode _keyCode, System.Type _stateTo) {
        _state.AddTransition(new Transition<PlayerStateManager>(
            (x) => {
                if (Input.GetKeyDown(_keyCode))
                    return true;
                return false;
            }, _stateTo));
    }
    public void AddTransitionWithBool(State<PlayerStateManager> _state, bool _bool, System.Type _stateTo) {
        _state.AddTransition(new Transition<PlayerStateManager>(
            (x) => {
                if (_bool)
                    return true;
                return false;
            }, _stateTo));
    }
}
