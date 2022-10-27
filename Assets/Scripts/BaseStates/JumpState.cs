using UnityEngine;

public class JumpState : BaseState
{
    private Rigidbody2D rigidBody;

    private float forceJump;
    private float speedRun;

    public JumpState(IStateSwitcher stateSwitcher, Animator animator, Rigidbody2D rigidBody, float forceJump, float speedRun) 
    : base(stateSwitcher, animator)
    {
        this.rigidBody = rigidBody;
        this.forceJump = forceJump;
        this.speedRun = speedRun;
    }

    public override void Enter()
    {
        animator.CrossFade(HashAnimationNames.Jump, 0.1f);

        rigidBody.velocity = new Vector2(rigidBody.velocity.x, forceJump);
    }

    public override void Exit()
    {
        animator.StopPlayback();
    }

    public override void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        rigidBody.velocity = new Vector2(moveHorizontal * speedRun, rigidBody.velocity.y);

        if (rigidBody.velocity.y < 0)
            stateSwitcher.SwitchState<FallState>();
    }
}
