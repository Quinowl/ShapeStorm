using System.Collections;
using UnityEngine;

public class PlayerDamageable : Damageable
{
    [SerializeField] private PlayerConfiguration _configuration;
    [SerializeField] private Collider _collider;

    private bool _isInvulnerable;
    private Coroutine _invulnerabilityCoroutine;

    public override void TakeDamage(int damage)
    {
        if (_isInvulnerable) return;
        if (_invulnerabilityCoroutine != null) StopCoroutine(_invulnerabilityCoroutine);
        _invulnerabilityCoroutine = StartCoroutine(InvulnerabilityCoroutine());
        base.TakeDamage(damage);
    }

    protected override void DamageEffects()
    {
        base.DamageEffects();
        ServiceLocator.Instance.GetService<CameraService>().ActivateShake();
    }

    private IEnumerator InvulnerabilityCoroutine()
    {
        SetInvulnerable(true);
        yield return new WaitForSeconds(_configuration.invulnerabilityTimeAfterTakeDamage);
        SetInvulnerable(false);
    }

    private void SetInvulnerable(bool isInvulnerable)
    {
        _isInvulnerable = isInvulnerable;
        _collider.enabled = !isInvulnerable;
    }
}