using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Configurations/Player Configuration")]
public class PlayerConfiguration : ScriptableObject
{
    [Header("Movement fields")]
    public float speed = 3f;

    [Header("Shoot fields")]
    public float shootCadency = 0.5f;
    public BaseProjectile projectilePrefab;
    public float projectileSpeed;
    public int projectileDamage;
    public float projectileLifeTime;
}