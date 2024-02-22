using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearSpawnPointStrategy : ISpawnPointStrategy
{
    int index = 0;
    Transform[] _spawnPoints;

    public LinearSpawnPointStrategy(Transform[] spawnPoints)
    {
        _spawnPoints = spawnPoints;
    }

    public Transform NextSpawnPoint()
    {
        Transform result = _spawnPoints[index];
        index = (index + 1) % _spawnPoints.Length;
        return result;
    }
}
