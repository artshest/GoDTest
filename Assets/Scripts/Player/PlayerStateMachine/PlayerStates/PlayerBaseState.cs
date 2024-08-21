
public abstract class PlayerBaseState
{
    protected PlayerStateMachine _context;
    protected PlayerStateFactory _factory;

    public PlayerBaseState(PlayerStateMachine context, PlayerStateFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public virtual void EnterState()
    {
    }
    public virtual void UpdateState()
    {
    }

    public abstract void ExitState();

    public virtual void CheckSwitchStates()
    {
    }
    protected void SwitchState(PlayerBaseState newState)
    {
        ExitState();
        _context.CurrentState = newState;
        newState.EnterState();
    }

}