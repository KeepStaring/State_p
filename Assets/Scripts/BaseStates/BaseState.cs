using UnityEngine;

public abstract class BaseState
{
    protected readonly IStateSwitcher stateSwitcher;

    protected readonly Animator animator;

    public BaseState(IStateSwitcher stateSwitcher, Animator animator)
    {
        this.stateSwitcher = stateSwitcher;
        this.animator = animator;
    }

    public abstract void Enter();
    public abstract void Exit();

    public virtual void Update() { }
    public virtual void FixedUpdate() { }
}
