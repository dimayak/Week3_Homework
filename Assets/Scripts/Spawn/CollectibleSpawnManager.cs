using UnityEngine;

public class CollectibleSpawnManager : EntitySpawnManager
{
    [SerializeField] private CollectibleData[] _collectibleData;

    EntitySpawner<Collectible> _spawner;

    protected override void Awake()
    {
        base.Awake();

        _spawner = new EntitySpawner<Collectible>(new EntityFactory<Collectible>(_collectibleData), _spanwPointStrategy);
    }

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.Length; ++i) {
            Spawn();
        }
    }

    public override void Spawn()
    {
        _spawner.Spawn();
    }
}