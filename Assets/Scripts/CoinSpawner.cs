using UnityEngine;

public class CoinSpawner : Spawner
{
    [SerializeField] private Vector2 _offsetBetweenItems;
    [SerializeField] private Vector2 _maxPositionVariation;

    protected override void Spawn(SpawnedItem itemToSpawn)
    {
        Vector2 SpawmPosition = _pivotPositionCalculator.GetNextPivotPosition() + GetRandomOffset();

        itemToSpawn.transform.position = SpawmPosition;
    }

    private Vector2 GetRandomOffset()
    {
        float randomXOffset = Random.Range(-_maxPositionVariation.x, _maxPositionVariation.x);
        float randomYOffset = Random.Range(0, _maxPositionVariation.y);

        return new Vector2(randomXOffset, randomYOffset);
    }
}
