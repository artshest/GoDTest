using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerStateMachine : CharacterBehavior, IDamageable
{
    public Action OnAttackActionDamage;
    public Action OnAttackActionEnd;

    private PlayerBaseState _currentState;
    private PlayerStateFactory _stateFactory;
    private HealthBarHandler _healthBarHandler;

    [SerializeField] private Image _healthBar;

    [SerializeField] private PlayerInputHandler _input;
    public PlayerInputHandler InputHandler { get => _input; }

    public CharacterController PlayerController { get; private set; }
    public CharacterAnimationHandler AnimationHandler { get => _animationHandler; }

    private PlayerTarget _target;

    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }


    protected override void Awake()
    {
        base.Awake();

        _stateFactory = new PlayerStateFactory(this);
        _currentState = _stateFactory.Idle();
        _currentState.EnterState();

        PlayerController = GetComponent<CharacterController>();

        _health = new Health(100);
        _health.OnDead += _health_OnDead;
        _health.OnHealthChanged += _health_OnHealthChanged;
        _healthBarHandler = new HealthBarHandler(_healthBar);

        _target = new PlayerTarget(this);
        ServiceLocator.Instance.Register(_target);
    }

    private void _health_OnHealthChanged(int arg1, int arg2)
    {
        _healthBarHandler.UpdateHealthBar(arg1, arg2);
    }

    private void Update()
    {
        _currentState.CheckSwitchStates();
        _currentState.UpdateState();
    }

    private void _health_OnDead()
    {
        ServiceLocator.Instance.Get<SceneController>().ReloadLevel();
    }

    private void OnDestroy()
    {
        _health.OnDead -= _health_OnDead;
    }

    public override void OnAttackDamage()
    {
        OnAttackActionDamage?.Invoke();
    }

    public override void OnAttackEnd()
    {
        OnAttackActionEnd?.Invoke();
    }
}
