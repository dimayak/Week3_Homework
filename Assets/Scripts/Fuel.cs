using UnityEngine;

public class Fuel : Collectible
{
    [SerializeField] private int _amount = 50;

    public int Amount => _amount;
}
