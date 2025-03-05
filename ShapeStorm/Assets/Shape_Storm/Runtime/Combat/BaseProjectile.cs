using UnityEngine;

public abstract class BaseProjectile : Entity {

    private float lifeTime;

    public void SetBullet(float _lifeTime) {
        lifeTime = _lifeTime;
    }
}