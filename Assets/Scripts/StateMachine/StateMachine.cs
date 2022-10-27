public class StateMachine
{
    public BaseState CurrentState { get; private set; }

    public void Initialize(BaseState startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    }

    public void ChangeState(BaseState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
