using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine context, PlayerStateFactory factory) : base(context, factory)
    {
    }

    public override void CheckSwitchStates()
    {
        base.CheckSwitchStates();
        
        if(_context.InputHandler.GetFrameVelocity() != Vector3.zero) 
        {
            SwitchState(_factory.Move());
        }
    }

    public override void EnterState()
    {
        base.EnterState();
        _context.InputHandler.OnAttack += InputHandler_OnAttack;
    }

    private void InputHandler_OnAttack()
    {
        SwitchState(_factory.Attack());
    }

    public override void ExitState()
    {
        _context.InputHandler.OnAttack -= InputHandler_OnAttack;
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
