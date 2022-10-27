using UnityEngine;

public class IdleState : BaseState
{
    private Rigidbody2D rigidBody;

    public IdleState(IStateSwitcher stateSwitcher, Animator animator, Rigidbody2D rigidBody) : base(stateSwitcher, animator)
    {
        this.rigidBody = rigidBody;
    }

    public override void Enter()
    {
        animator.CrossFade(HashAnimationNames.Idle, 0.1f);
    }

    public override void Exit()
    {
        animator.StopPlayback();
    }

    public override void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
            stateSwitcher.SwitchState<RunState>();

        if (Input.GetKeyDown(KeyCode.Space))
            stateSwitcher.SwitchState<JumpState>();
    }

    public override void FixedUpdate()
    {
        if (rigidBody.velocity.y < 0)
            stateSwitcher.SwitchState<FallState>();
    }
}
