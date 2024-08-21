using UnityEngine;

public class CharacterAnimationHandler 
{
    private Animator _animator;

    private int _isWalkingHash;
    private int _xVelocityHash;
    private int _zVelocityHash;
    private int _attackHash;
    private int _onTakeDamageHash;
    private int _onDeadHash;

    public CharacterAnimationHandler(Animator animator)
    {
        _animator = animator;

        _isWalkingHash = Animator.StringToHash("IsWalking");
        _xVelocityHash = Animator.StringToHash("xVelocity");
        _zVelocityHash = Animator.StringToHash("zVelocity");
        _attackHash = Animator.StringToHash("Attack");
        _onTakeDamageHash = Animator.StringToHash("OnTakeDamage");
        _onDeadHash = Animator.StringToHash("OnDead");
    }

    public void SetTakeDamage()
    {
        _animator.SetTrigger(_onTakeDamageHash);
    }

    public void SetDead() 
    {
        _animator.SetTrigger(_onDeadHash);
    }

    public void SetWalking(bool isWalking)
    {
        _animator.SetBool(_isWalkingHash, isWalking);
    }

    public void SetMovment(Vector3 frameVelocity)
    {
        _animator.SetFloat(_xVelocityHash, frameVelocity.x);
        _animator.SetFloat(_zVelocityHash, frameVelocity.z);
    }

    public void SetAttack()
    {
        _animator.SetTrigger(_attackHash);
    }
}

