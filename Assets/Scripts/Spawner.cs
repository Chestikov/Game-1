using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected Vector2 _startSpawnPosition;
    [SerializeField] protected SpawnedItem _spawnItemPrefab;
    [SerializeField] protected Vector2 _offsetBetweenItems;
    [SerializeField] protected int _itemsPerScreen;
    protected Vector2 _currentSpawnPosition;
    protected float _ItemWidth;
    protected Queue<SpawnedItem> _items = new Queue<SpawnedItem>();


    protected void Start()
    {
        _ItemWidth = _spawnItemPrefab.GetComponent<Renderer>().bounds.size.x;
        _currentSpawnPosition = _startSpawnPosition;

        for (int i = 0; i < _itemsPerScreen; i++)
        {
            SpawnedItem newItem = Instantiate(_spawnItemPrefab, _currentSpawnPosition, Quaternion.identity, gameObject.transform);
            newItem.ItemDisabled += item => _items.Enqueue(item);

            ChangeSpawnPosition();
        }
    }

    private void Update()
    {
        if (_items.Count != 0)
        {
            var item = _items.Dequeue();
            item.transform.position = _currentSpawnPosition;
            item.gameObject.SetActive(true);

            ChangeSpawnPosition();
        }
    }

    protected virtual Vector2 GetMinOffsetBetweenItems() => new Vector2(_ItemWidth, 0);

    protected virtual void ChangeSpawnPosition()
    {
        Vector2 nextItemOffset = _offsetBetweenItems + GetMinOffsetBetweenItems();
        Vector2 newSpawnPosition = _currentSpawnPosition + nextItemOffset;

        _currentSpawnPosition = newSpawnPosition;
    }
}
