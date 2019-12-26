using System;
using UnityEngine;

public class SpawnedItem : MonoBehaviour
{
    public event Action<SpawnedItem> ItemDisabled;

    [ExecuteInEditMode]
    protected void OnDisable()
    {
        ItemDisabled?.Invoke(this);
    }

    protected void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
