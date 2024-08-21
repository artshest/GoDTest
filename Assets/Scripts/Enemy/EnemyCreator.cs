
public abstract class EnemyCreator 
{
    protected EnemyBehavior _prefab;

    public EnemyCreator(EnemyBehavior prefab)
    {
        _prefab = prefab;
    }

    public abstract EnemyBehavior InitEnemy(EnemyBehavior enemyObject);
    public abstract EnemyBehavior InstantiateEnemy();
    public abstract EnemyBehavior InstantiateEnemy(EnemyBehavior prefab);
}
