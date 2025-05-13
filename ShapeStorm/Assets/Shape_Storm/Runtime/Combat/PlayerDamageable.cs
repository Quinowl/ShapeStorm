using UnityEngine;

public class PlayerDamageable : Damageable
{
    protected override void DamageEffects()
    {
        base.DamageEffects();
        ServiceLocator.Instance.GetService<CameraService>().ActivateShake();
    }
}