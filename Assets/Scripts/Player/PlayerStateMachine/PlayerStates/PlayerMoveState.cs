using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerStateMachine context, PlayerStateFactory factory) : base(context, factory)
    {
    }

    public override void CheckSwitchStates()
    {
        base.CheckSwitchStates();

        if (_context.InputHandler.GetFrameVelocity() == Vector3.zero)
        {
            SwitchState(_factory.Idle());
        }
    }

    public override void EnterState()
    {
        base.EnterState();
        _context.AnimationHandler.SetWalking(true);
        _context.InputHandler.OnAttack += InputHandler_OnAttack;
    }

    private void InputHandler_OnAttack()
    {
        SwitchState(_factory.Attack());
    }

    public override void ExitState()
    {
        _context.AnimationHandler.SetWalking(false);
        _context.InputHandler.OnAttack -= InputHandler_OnAttack;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _context.PlayerController.Move(_context.InputHandler.GetFrameVelocity() * Time.deltaTime * _context.MoveSpeed);
        _context.AnimationHandler.SetMovment(_context.InputHandler.GetFrameVelocity());
    }
}
