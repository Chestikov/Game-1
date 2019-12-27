using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected Vector2 _startSpawnPosition;
    [SerializeField] protected SpawnedItem _spawnItemPrefab;
    [SerializeField] protected Vector2 _offsetBetweenItems;
    [SerializeField] protected int _itemsPerScreen;
    protected Vector2 _currentSpawnPosition;
    protected float _ItemWidth;

    protected void Start()
    {
        _ItemWidth = _spawnItemPrefab.GetComponent<Renderer>().bounds.size.x;
        _currentSpawnPosition = _startSpawnPosition;

        InitialSpawn();
    }

    protected virtual void InitialSpawn()
    {
        for (int i = 0; i < _itemsPerScreen; i++)
        {
            Vector2 spawnPosition = GetSpawnPosition();
            SpawnedItem newItem = Instantiate(_spawnItemPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
            newItem.RespawnRequested += Spawn;
        }
    }

    protected virtual void Spawn(SpawnedItem itemToSpawn)
    {
        Debug.Log(_currentSpawnPosition);
        itemToSpawn.transform.position = GetSpawnPosition();
    }

    protected virtual Vector2 GetMinOffsetBetweenItems() => new Vector2(_ItemWidth, 0);

    protected virtual void ChangeSpawnPosition()
    {
        Vector2 nextItemOffset = _offsetBetweenItems + GetMinOffsetBetweenItems();
        Vector2 newSpawnPosition = _currentSpawnPosition + nextItemOffset;

        _currentSpawnPosition = newSpawnPosition;
    }

    protected Vector2 GetSpawnPosition()
    {
        var spawnPosition = _currentSpawnPosition;
        ChangeSpawnPosition();
        return spawnPosition;
    }
}
