using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected SpawnedItem _spawnItemPrefab;
    [SerializeField] protected int _itemsPerScreen;
    [SerializeField] protected PivotPositionCalculator _pivotPositionCalculator;

    protected void Start()
    {
        InitialSpawn();
    }

    protected virtual void InitialSpawn()
    {
        for (int i = 0; i < _itemsPerScreen; i++)
        {
            Vector2 spawnPosition = _pivotPositionCalculator.GetNextPivotPosition();
            SpawnedItem newItem = Instantiate(_spawnItemPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
            newItem.RespawnRequested += Spawn;
        }
    }

    protected virtual void Spawn(SpawnedItem itemToSpawn)
    {
        itemToSpawn.transform.position = _pivotPositionCalculator.GetNextPivotPosition();
    }
}
