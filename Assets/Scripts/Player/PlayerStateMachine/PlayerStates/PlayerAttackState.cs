
public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerStateMachine context, PlayerStateFactory factory) : base(context, factory)
    {
    }

    public override void EnterState()
    {
        _context.AnimationHandler.SetAttack();
        _context.OnAttackActionDamage += _context_OnAttackActionDamage;
        _context.OnAttackActionEnd += _context_OnAttackActionEnd;
    }

    private void _context_OnAttackActionEnd()
    {
        SwitchState(_factory.Idle());
    }

    private void _context_OnAttackActionDamage()
    {
        _context.DealDamage();

        _context.OnAttackActionDamage -= _context_OnAttackActionDamage;
    }

    public override void ExitState()
    {
        _context.OnAttackActionEnd -= _context_OnAttackActionEnd;
    }
}
