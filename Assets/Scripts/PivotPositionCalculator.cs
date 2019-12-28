using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotPositionCalculator : MonoBehaviour
{
    [SerializeField] protected Vector2 _startSpawnPosition;
    [SerializeField] private Vector2 _distanceBetweenPivots;
    private Vector2 _currentSpawnPivotPosition;

    private void Start()
    {
        _currentSpawnPivotPosition = _startSpawnPosition;
    }

    public Vector2 GetNextPivotPosition()
    {
        Vector2 spawnPosition = _currentSpawnPivotPosition;

        _currentSpawnPivotPosition += _distanceBetweenPivots;

        return spawnPosition;
    }
}
