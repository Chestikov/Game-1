using System;
using UnityEngine;

public class SpawnedItem : MonoBehaviour
{
    private float _itemWidth;

    public event Action<SpawnedItem> RespawnRequested;
    
    public void RespawnRequest() => RespawnRequested?.Invoke(this);

    protected void Start()
    {
        _itemWidth = GetComponent<Renderer>().bounds.size.x;
    }

    protected void Update()
    {
        if (IsItemOutOfScreen())
        { 
            RespawnRequest();
        }
    }

    private Vector2 GetRightEdgePosition(float offsetFromPivotX, float offsetFromPivotY)
    {
        float rightEdgePositionX = transform.position.x + offsetFromPivotX;
        float rightEdgePositionY = transform.position.y + offsetFromPivotY;

        return new Vector2(rightEdgePositionX, rightEdgePositionY);
    }

    private bool IsItemOutOfScreen()
    {
        Vector2 itemRightEdgePosition = GetRightEdgePosition(_itemWidth / 2, 0);
        float itemRightEdgeScreenPositionX = Camera.main.WorldToScreenPoint(itemRightEdgePosition).x;

        float leftScreenEdgePositionX = 0;

        return itemRightEdgeScreenPositionX < leftScreenEdgePositionX;
    }
}
