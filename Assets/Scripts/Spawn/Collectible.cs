using System;
using UnityEngine;

public class Collectible : Entity
{
    [SerializeField] protected string _collectorTag = "Player";

    public static event Action<Collectible> OnCollected;

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_collectorTag))
        {
            OnCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
