using UnityEngine;

public class WeakEnemyCreator : EnemyCreator
{
    private int _health = 15;
    private float _moveSpeed = 0.4f;

    public WeakEnemyCreator(EnemyBehavior prefab) : base(prefab)
    {
    }

    public override EnemyBehavior InitEnemy(EnemyBehavior enemyObject)
    {
        enemyObject.Construct(_health, _moveSpeed);
        return enemyObject;
    }

    public override EnemyBehavior InstantiateEnemy()
    {
        EnemyBehavior EnemyObject = GameObject.Instantiate(_prefab);
        EnemyObject.Construct(_health, _moveSpeed);
        return EnemyObject;
    }

    public override EnemyBehavior InstantiateEnemy(EnemyBehavior prefab)
    {
        EnemyBehavior EnemyObject = GameObject.Instantiate(prefab);
        EnemyObject.Construct(_health, _moveSpeed);
        return EnemyObject;
    }
}
