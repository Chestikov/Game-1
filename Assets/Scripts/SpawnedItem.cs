using System;
using UnityEngine;

public class SpawnedItem : MonoBehaviour
{
    public event Action<SpawnedItem> RespawnRequested;

    public void RespawnRequest() => RespawnRequested?.Invoke(this);

    protected void OnBecameInvisible() => RespawnRequest();
}
