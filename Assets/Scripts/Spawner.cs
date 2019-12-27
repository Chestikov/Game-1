using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected Vector2 _startSpawnPosition;
    [SerializeField] protected SpawnedItem _spawnItemPrefab;
    [SerializeField] protected int _itemsPerScreen;
    protected Vector2 _currentSpawnPosition;
    protected float _ItemWidth;

    protected Vector2 CurrentSpawnPosition
    {
        get
        {
            var spawnPosition = _currentSpawnPosition;
            ChangeSpawnPosition();
            return spawnPosition;
        }
    }

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
            Vector2 spawnPosition = CurrentSpawnPosition;
            SpawnedItem newItem = Instantiate(_spawnItemPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
            newItem.RespawnRequested += Spawn;
        }
    }

    protected virtual void Spawn(SpawnedItem itemToSpawn)
    {
        itemToSpawn.transform.position = CurrentSpawnPosition;
    }

    protected virtual Vector2 GetMinOffsetBetweenItems() => new Vector2(_ItemWidth, 0);

    protected abstract void ChangeSpawnPosition();
}
