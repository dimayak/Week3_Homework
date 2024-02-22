using UnityEngine;

public abstract class EntitySpawnManager : MonoBehaviour
{
    protected enum SpawnPointStrategyType {
        Linear,
        Random
    }

    [SerializeField] protected SpawnPointStrategyType _spawnPointStrategyType = SpawnPointStrategyType.Linear;
    [SerializeField] protected Transform[] _spawnPoints;

    protected ISpawnPointStrategy _spanwPointStrategy;

    protected virtual void Awake()
    {
        if (_spawnPointStrategyType == SpawnPointStrategyType.Linear)
        {
            _spanwPointStrategy = new LinearSpawnPointStrategy(_spawnPoints);
        }
        else if (_spawnPointStrategyType == SpawnPointStrategyType.Random)
        {
            _spanwPointStrategy = new RandomSpawnPointStrategy(_spawnPoints);
        }
    }

    public abstract void Spawn();
}