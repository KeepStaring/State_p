using UnityEngine;

public class RunState : BaseState
{
    private Rigidbody2D rigidBody;

    private float speed;

    public RunState(IStateSwitcher stateSwitcher, Animator animator, Rigidbody2D rigidBody, float speed) 
    : base(stateSwitcher, animator)
    {
        this.rigidBody = rigidBody;
        this.speed = speed;
    }

    public override void Enter()
    {
        animator.CrossFade(HashAnimationNames.Run, 0.1f);
    }

    public override void Exit()
    {
        animator.StopPlayback();
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            stateSwitcher.SwitchState<JumpState>();

        if (Input.anyKey == false)
            stateSwitcher.SwitchState<BrakingState>();
    }

    public override void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        rigidBody.velocity = new Vector2(moveHorizontal * speed, rigidBody.velocity.y);

        if (rigidBody.velocity.x == 0)
            stateSwitcher.SwitchState<IdleState>();

        if (rigidBody.velocity.y < 0)
            stateSwitcher.SwitchState<FallState>();
    }
}
