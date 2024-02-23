using UnityEngine;

public class Coin : Collectible
{
    [SerializeField] private int _amount = 1;

    public int Amount => _amount;
}
