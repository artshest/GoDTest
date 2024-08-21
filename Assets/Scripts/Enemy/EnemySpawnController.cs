using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    private WeakEnemyCreator _weakEnemyCreator;
    private EnemyPool _weakEnemyPool;

    [SerializeField] private EnemyBehavior _enemyBehavior;

    private float _gameplayTime;
    private int _currentEnemyCount;

    [SerializeField] private int _maxEnemyCount;
    [SerializeField] private float _maxEnemyCountInreaseTime;

    private void Awake()
    {
        EnemyBehavior.OnEnemyDead += EnemyBehavior_OnEnemyDead;

        _weakEnemyCreator = new WeakEnemyCreator(_enemyBehavior);
        _weakEnemyPool = new EnemyPool(_enemyBehavior, _weakEnemyCreator);
    }

    private void Update()
    {
        HandleEnemySpawn();
    }

    private void HandleEnemySpawn()
    {
        _gameplayTime += Time.deltaTime;

        if (_gameplayTime > _maxEnemyCountInreaseTime)
        {
            _gameplayTime = 0;
            _maxEnemyCount++;
        }

        if (_currentEnemyCount < _maxEnemyCount)
        {
            EnemyBehavior enemy = _weakEnemyPool.Get();
            enemy.transform.position = ServiceLocator.Instance.Get<PlayerTarget>().GetTargetPosition() + new Vector3(7, 0, Random.Range(-2f, 2f));
            _currentEnemyCount++;
        }
    }

    private void EnemyBehavior_OnEnemyDead(EnemyBehavior enemy)
    {
        _currentEnemyCount--;
    }
}