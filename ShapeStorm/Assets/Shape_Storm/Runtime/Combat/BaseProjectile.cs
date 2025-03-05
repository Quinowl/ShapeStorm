using System;
using UnityEngine;

public abstract class BaseProjectile : Entity {

    protected float speed;
    private float damage;
    private float lifeTime;
    private Action destroyAction;

    protected override void OnEnable() {
        base.OnEnable();
    }

    protected override void UpdateStep() {
        base.UpdateStep();
        Movement();
    }

    protected virtual void Movement() {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public virtual void SetBullet(float _speed, float _damage, float _lifeTime, Vector3 _position, Quaternion _rotation, Action _destroyAction) {
        speed = _speed;
        damage = _damage;
        lifeTime = _lifeTime;
        transform.position = _position;
        transform.rotation = _rotation;
        destroyAction = _destroyAction;
    }
}