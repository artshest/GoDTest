using System;
using System.Collections;
using UnityEngine;

public class EnemyBehavior : CharacterBehavior, IDamageable
{
    public static event Action<EnemyBehavior> OnEnemyDead;

    private ITarget _target;

    private Vector3 _frameVelocity;

    [SerializeField] private float _attackDistanceOffset;

    private enum State
    {
        Chase,
        Attack,
        Cooldown
    }

    private State _state;

    public void Construct(int health, float moveSpeed)
    {
        _health = new Health(health);
        _health.OnDead += _health_OnDead;
        _moveSpeed = moveSpeed;
    }

    private void Start()
    {
        _target = ServiceLocator.Instance.Get<PlayerTarget>();

        Construct(10, _moveSpeed);
    }

    private void OnEnable()
    {
        SetChaseState();
    }

    private void Update()
    {
        if (_state == State.Chase)
        {
            Chase();
        }
    }

    private void _health_OnDead()
    {
        _animationHandler.SetDead();
        OnEnemyDead?.Invoke(this);
    }

    public void SetCooldownState()
    {
        _state = State.Cooldown;
        if (isActiveAndEnabled)
        {
            StartCoroutine(DelayCooldown());
        }
    }

    private IEnumerator DelayCooldown()
    {
        yield return new WaitForSeconds(2f);
        _state = State.Chase;
    }

    private void SetChaseState()
    {
        _state = State.Chase;
        _animationHandler.SetWalking(true);
    }

    private void Chase()
    {
        var targetPosition = _target.GetTargetPosition();
        targetPosition.x += 1;
        var moveVector = targetPosition - transform.position;
        moveVector.y = 0;

        if (moveVector.magnitude < _attackDistanceOffset)
        {
            SetAttackState();
            _animationHandler.SetWalking(false);
            return;
        }

        _frameVelocity = moveVector.normalized;
        _animationHandler.SetMovment(_frameVelocity * -1);
        transform.position += _frameVelocity * _moveSpeed * Time.deltaTime;
    }

    private void SetAttackState()
    {
        _animationHandler.SetAttack();
        _state = State.Attack;
    }

    public override void OnAttackDamage()
    {
        if (_state != State.Attack) 
        {
            return;
        }

        DealDamage();
        SetCooldownState();
    }


    private void OnDestroy()
    {
        _health.OnDead -= _health_OnDead;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _animationHandler.SetTakeDamage();
        SetCooldownState();
    }
}
