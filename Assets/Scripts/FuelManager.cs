using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    [SerializeField] private float _maxFuelAmount = 1000;
    [SerializeField] private float _fuelSpendRate = 10.0f;
    private float _currentFuelAmount = 1000;

    public float MaxFuelAmount => _maxFuelAmount;
    public float CurrentFuelAmount => _currentFuelAmount;

    public static Action<FuelManager> OnFuelAmountChanged = delegate {};
    public static Action<FuelManager> OnFuelFinished = delegate {};

    private void OnEnable()
    {
        Collectible.OnCollected += Collectible_OnCollected;
    }

    private void OnDisable()
    {
        Collectible.OnCollected -= Collectible_OnCollected;
    }

    void Update()
    {
        _currentFuelAmount -= _fuelSpendRate * Time.deltaTime;
        OnFuelAmountChanged.Invoke(this);

        if (_currentFuelAmount <= 0.0f)
        {
            _currentFuelAmount = 0.0f;
            OnFuelFinished.Invoke(this);
        }
    }

    private void Collectible_OnCollected(Collectible collectible)
    {
        if (collectible.GetType() != typeof(Fuel)) {
            return;
        }

        Fuel fuel = (Fuel)collectible;

        _currentFuelAmount += fuel.Amount;
        if (_currentFuelAmount >= _maxFuelAmount) {
            _currentFuelAmount = _maxFuelAmount;
        }

        OnFuelAmountChanged.Invoke(this);
    }
}
