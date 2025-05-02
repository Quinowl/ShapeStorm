using UnityEngine;

public abstract class Damageable : MonoBehaviour 
{
    protected int _currentHealth;
    
    public virtual void TakeDamage(int damage)
    {
        if (_currentHealth <= 0) Die();
    }

    protected virtual void Die()
    {
        
    }
    
    protected virtual void DamageEffects() { }
    
    protected virtual void DieEffects() { }
}