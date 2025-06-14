using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Configurations/Enemies/Turret")]
public class BaseEnemyConfiguration : ScriptableObject
{
    [Header("Base fields")]
    public float shootCadency = 0.1f;
    [Range(0f, 1f)] public float destroyableProjectileProb = 0.1f;
    [Header("Projectile fields")]
    public float projectileSpeed = 0.3f;
    public int projectileDamage = 3;
    public float projectileLifeTime = 3f;
}