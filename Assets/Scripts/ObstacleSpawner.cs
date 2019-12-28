using UnityEngine;

public class ObstacleSpawner : Spawner
{
    [SerializeField] private Vector2 _offsetFromPivot;

    protected override void Spawn(SpawnedItem itemToSpawn)
    {
        Vector2 SpawmPosition = _pivotPositionCalculator.GetNextPivotPosition() + _offsetFromPivot;

        itemToSpawn.transform.position = SpawmPosition;
    }
}
