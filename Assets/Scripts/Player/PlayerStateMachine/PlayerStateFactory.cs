
public class PlayerStateFactory
{
    protected PlayerStateMachine _context;

    public PlayerStateFactory(PlayerStateMachine context)
    {
        _context = context;
    }
    public PlayerBaseState Idle()
    {
        return new PlayerIdleState(_context, this);
    }

    public PlayerBaseState Move()
    {
        return new PlayerMoveState(_context, this);
    }

    internal PlayerBaseState Attack()
    {
        return new PlayerAttackState(_context, this);
    }
}

