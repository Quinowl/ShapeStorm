using System;
using UnityEngine;

public abstract class BaseProjectile : Entity
{
    protected float _speed;
    private float _damage;
    private float _lifeTime;
    private Action _destroyAction;

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void UpdateStep()
    {
        base.UpdateStep();
        Movement();
    }

    protected virtual void Movement()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    public virtual void SetBullet(float _speed, float _damage, float _lifeTime, Vector3 _position, Quaternion _rotation, Action _destroyAction)
    {
        this._speed = _speed;
        this._damage = _damage;
        this._lifeTime = _lifeTime;
        transform.position = _position;
        transform.rotation = _rotation;
        this._destroyAction = _destroyAction;
    }
}