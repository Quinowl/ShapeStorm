using System;
using System.Collections.Generic;

public class ServiceLocator
{
    private static ServiceLocator _instance;
    public static ServiceLocator Instance => _instance ??= new ServiceLocator();

    private readonly Dictionary<Type, object> _services;

    private ServiceLocator() => _services = new Dictionary<Type, object>();

    public void RegisterService<T>(T service)
    {
        var type = typeof(T);
        if (!_services.ContainsKey(type)) _services.Add(type, service);
    }

    public T GetService<T>()
    {
        var type = typeof(T);
        if (_services.TryGetValue(type, out var service)) return (T)service;
        throw new Exception($"Service {type} not found.");
    }

    public void UnregisterService<T>()
    {
        var type = typeof(T);
        if (_services.ContainsKey(type))
        {
            _services.Remove(type);
            return;
        }
        throw new Exception($"Service {type} is not registered.");
    }
}