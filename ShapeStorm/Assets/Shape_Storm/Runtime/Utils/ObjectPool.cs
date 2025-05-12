using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private readonly T _prefab;
    private readonly Transform _parentTransform;
    private readonly Queue<T> _pool = new Queue<T>();

    public ObjectPool(T prefab, int initialSize = 10, Transform parentTransform = null)
    {
        this._prefab = prefab;
        this._parentTransform = parentTransform;
        for (int i = 0; i < initialSize; i++) AddObjectToPool();
    }

    public T Get()
    {
        if (_pool.Count == 0) AddObjectToPool();
        T obj = _pool.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }

    private void AddObjectToPool()
    {
        T obj = Object.Instantiate(_prefab, _parentTransform);
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }
}