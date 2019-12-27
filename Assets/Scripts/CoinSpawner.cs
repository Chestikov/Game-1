using UnityEngine;

public class CoinSpawner : Spawner
{
    [SerializeField] private Vector2 _offsetBetweenItems;
    [SerializeField] private Vector2 _maxPositionVariation;

    protected override void ChangeSpawnPosition()
    {
        Vector2 nextItemOffset = _offsetBetweenItems + GetMinOffsetBetweenItems();
        Vector2 newSpawnPosition = _currentSpawnPosition + nextItemOffset;

        _currentSpawnPosition = newSpawnPosition;
    }

    protected override void Spawn(SpawnedItem itemToSpawn)
    {
        Vector2 SpawmPosition = CurrentSpawnPosition + GetRandomOffset();

        itemToSpawn.transform.position = SpawmPosition;
    }

    private Vector2 GetRandomOffset()
    {
        float randomXOffset = Random.Range(-_maxPositionVariation.x, _maxPositionVariation.x);
        float randomYOffset = Random.Range(0, _maxPositionVariation.y);

        return new Vector2(randomXOffset, randomYOffset);
    }
}
