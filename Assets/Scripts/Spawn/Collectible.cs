using System;
using UnityEngine;

public class Collectible : Entity
{
    [SerializeField] private int _points = 1;
    [SerializeField] private string _collectorTag = "Player";

    public int Points => _points;

    public static event Action<Collectible> OnCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_collectorTag))
        {
            OnCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
