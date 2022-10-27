using UnityEngine;

public class BrakingState : BaseState
{
    private Rigidbody2D rigidBody;

    public BrakingState(IStateSwitcher stateSwitcher, Animator animator, Rigidbody2D rigidBody) : base(stateSwitcher, animator)
    {
        this.rigidBody = rigidBody;
    }

    public override void Enter()
    {
        animator.CrossFade(HashAnimationNames.Braking, 0.1f);
    }

    public override void Exit()
    {
        animator.StopPlayback();
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            stateSwitcher.SwitchState<JumpState>();

        if (rigidBody.velocity.x == 0)
            stateSwitcher.SwitchState<IdleState>();
    }
}
