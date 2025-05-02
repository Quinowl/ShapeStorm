using UnityEngine;

public abstract class Damageable : MonoBehaviour 
{
    [SerializeField] protected ShakeComponent _shakeComponent;
    protected int _currentHealth;

    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        DamageEffects();
        if (_currentHealth <= 0) Die();
    }

    protected virtual void Die()
    {
        DieEffects();
    }

    protected virtual void DamageEffects()
    {
        
    }
    
    protected virtual void DieEffects() { }
}