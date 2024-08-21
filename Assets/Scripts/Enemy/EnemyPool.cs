using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool
{
    private ObjectPool<EnemyBehavior> _pool;
    private EnemyBehavior _prefab;
    private EnemyCreator _creator;

    public EnemyPool(EnemyBehavior prefab, EnemyCreator creator)
    {
        _prefab = prefab;
        _pool = new ObjectPool<EnemyBehavior>(OnCreateEnemy, OnGetEnemy, OnRelease, OnEnemyDestroy, false);
        _creator = creator;

        EnemyBehavior.OnEnemyDead += EnemyBehavior_OnEnemyDead;
    }

    private void EnemyBehavior_OnEnemyDead(EnemyBehavior obj)
    {
        Release(obj);
    }

    public EnemyBehavior Get()
    {
        var enemy = _pool.Get();
        _creator.InitEnemy(enemy);
        return enemy;
    }

    public void Release(EnemyBehavior enemy)
    {
        _pool.Release(enemy);
    }

    private void OnEnemyDestroy(EnemyBehavior enemy)
    {
        Object.Destroy(enemy);
    }

    private void OnRelease(EnemyBehavior enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void OnGetEnemy(EnemyBehavior enemy)
    {
        enemy.gameObject.SetActive(true);
    }

    private EnemyBehavior OnCreateEnemy()
    {
        return _creator.InstantiateEnemy(_prefab);
    }
}