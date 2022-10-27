using UnityEngine;

public class FallState : BaseState
{
    private Rigidbody2D rigidBody;

    private float speedRun;

    public FallState(IStateSwitcher stateSwitcher, Animator animator, Rigidbody2D rigidBody, float speedRun) 
    : base(stateSwitcher, animator)
    {
        this.rigidBody = rigidBody;
        this.speedRun = speedRun;
    }

    public override void Enter()
    {
        animator.CrossFade(HashAnimationNames.Fall, 0.1f);
    }

    public override void Exit()
    {
        animator.StopPlayback();
    }

    public override void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        rigidBody.velocity = new Vector2(moveHorizontal * speedRun, rigidBody.velocity.y);

        if (rigidBody.velocity.y == 0)
        {
            if (moveHorizontal != 0)
            {
                stateSwitcher.SwitchState<RunState>();
                return;
            }

            stateSwitcher.SwitchState<IdleState>();
        }
    }
}
