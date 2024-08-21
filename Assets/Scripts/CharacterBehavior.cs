using UnityEngine;


[RequireComponent(typeof(Animator), typeof(Collider))]
public abstract class CharacterBehavior : MonoBehaviour, IDamageable
{
    protected Health _health;

    protected CharacterAnimationHandler _animationHandler;

    [Header("Move attributes")]
    [SerializeField]
    protected float _moveSpeed;
    public float MoveSpeed { get => _moveSpeed; }

    [Header("Damage attributes")]
    [SerializeField]
    protected GameObject _damagePoint;
    public GameObject DamagePoint { get => _damagePoint; }

    [SerializeField]
    private float _damageColliderRadius;
    public float DamageColliderRadius { get => _damageColliderRadius; }

    [SerializeField]
    private int _damage;

    protected virtual void Awake()
    {
        _animationHandler = new CharacterAnimationHandler(GetComponent<Animator>());
    }

    public virtual void DealDamage()
    {
        Collider[] Damageables = Physics.OverlapSphere(
            DamagePoint.transform.position,
            DamageColliderRadius,
            LayerMask.GetMask("Damageable"));

        foreach (var collider in Damageables)
        {
            IDamageable damageable;
            collider.gameObject.TryGetComponent(out damageable);
            damageable.TakeDamage(_damage);
        }
    }

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(DamagePoint.transform.position, DamageColliderRadius);
    }

    public virtual void TakeDamage(int damage)
    {
        _health.Reduce(damage);
    }

    public abstract void OnAttackDamage();

    public virtual void OnAttackEnd() { }
}
