using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PlayerBehaviour : MonoBehaviour, IStateSwitcher
{
    [SerializeField] private Animator animator;

    [SerializeField] private float speedRun;
    [SerializeField] private float jumpForce;

    private List<BaseState> allState;

    private StateMachine stateMachine;

    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        allState = new List<BaseState>()
        {
            new IdleState(this, animator, rigidBody),
            new RunState(this, animator, rigidBody, speedRun),
            new JumpState(this, animator, rigidBody, jumpForce, speedRun),
            new FallState(this, animator, rigidBody, speedRun),
            new BrakingState(this, animator, rigidBody)
        };

        stateMachine = new StateMachine();
        stateMachine.Initialize(allState[0]);
    }

    private void Update()
    {
        stateMachine.CurrentState.Update();
    }

    private void FixedUpdate()
    {
        if (rigidBody.velocity.x > 0)
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
        else if (rigidBody.velocity.x < 0)
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);

        stateMachine.CurrentState.FixedUpdate();
    }

    public void SwitchState<T>() where T : BaseState
    {
        var newState = allState.FirstOrDefault(s => s is T);

        stateMachine.ChangeState(newState);
    }

}
