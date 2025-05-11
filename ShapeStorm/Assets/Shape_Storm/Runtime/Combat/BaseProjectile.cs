using System;
using UnityEngine;

public abstract class BaseProjectile : Entity
{
    [SerializeField] protected Rigidbody _rb;

    protected float _speed;
    protected int _damage;
    protected float _lifeTime;
    protected Action _destroyAction;

    private float _enabledTime;

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void UpdateStep()
    {
        base.UpdateStep();
        if (Time.time >= _lifeTime + _enabledTime) _destroyAction?.Invoke();
    }

    public virtual void SetBullet(float _speed, int _damage, float _lifeTime, Vector3 _position, Quaternion _rotation, Action _destroyAction)
    {
        this._speed = _speed;
        this._damage = _damage;
        this._lifeTime = _lifeTime;
        transform.position = _position;
        transform.rotation = _rotation;
        this._destroyAction = _destroyAction;
        _rb.linearVelocity = transform.forward * _speed;
        _enabledTime = Time.time;
    }
}