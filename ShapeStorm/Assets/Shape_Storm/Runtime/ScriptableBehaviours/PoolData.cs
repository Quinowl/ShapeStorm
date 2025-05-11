using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Pool data")]
public class PoolData : ScriptableObject
{
    public GameObject prefab;
    public int initialSize;
    public T TryGetComponentOnPrefab<T>() where T : Component
    {
        if (prefab.TryGetComponent(out T component)) return component;
        Debug.Log($"Prefab {prefab} hasn't {component} component, returning null.");
        return null;
    }
}