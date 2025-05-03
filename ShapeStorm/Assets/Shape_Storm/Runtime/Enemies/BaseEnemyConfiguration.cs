using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Configurations/Enemies/Static")]
public class BaseEnemyConfiguration : ScriptableObject
{
    public float shootCadency = 0.1f;
    public BaseProjectile projectilePrefab;
}