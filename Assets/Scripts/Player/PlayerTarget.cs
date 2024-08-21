using UnityEngine;

public class PlayerTarget :ITarget, IService
{
    private PlayerStateMachine _player;

    public PlayerTarget(PlayerStateMachine player)
    {
        _player = player;
    }

    public IDamageable GetTarget()
    {
        return _player;
    }
    public Vector3 GetTargetPosition()
    { 
        return _player.transform.position;
    }
}
