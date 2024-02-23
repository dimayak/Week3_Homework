using System;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int _totalCoinsCount = 0;
    private int _currentCoinsCount = 0;

    // Вызывается, когда собраны все монеты на сцене
    public static Action<int> OnAllCoinsCollected;
    // Активируется, когда меняется текущее количество монет
    // Аргументы: текущее количество монет, общее количество монет
    public static Action<int, int> OnCurrentCoinsChanged;

    private void Start()
    {
        _totalCoinsCount = FindObjectsByType(typeof(Collectible), FindObjectsSortMode.None).Length;
        _currentCoinsCount = 0;
        OnCurrentCoinsChanged_Invoke();
    }

    private void OnEnable()
    {
        Collectible.OnCollected += Collectible_OnCollected;
    }

    private void OnDisable()
    {
        Collectible.OnCollected -= Collectible_OnCollected;
    }

    private void Collectible_OnCollected(Collectible collectible)
    {
        if (collectible.GetType() != typeof(Coin)) {
            return;
        }

        _currentCoinsCount++;
        OnCurrentCoinsChanged_Invoke();
        if (_currentCoinsCount >= _totalCoinsCount)
        {
            OnAllCoinsCollected?.Invoke(_totalCoinsCount);
            Debug.Log("[CoinManager] OnAllCoinsCollected");
        }
    }

    private void OnCurrentCoinsChanged_Invoke()
    {
        OnCurrentCoinsChanged?.Invoke(_currentCoinsCount, _totalCoinsCount);
    }
}
