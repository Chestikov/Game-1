using UnityEngine;

public class Coin : SpawnedItem
{
    [SerializeField] private int _value = 1;

    public int Value => _value;
}
