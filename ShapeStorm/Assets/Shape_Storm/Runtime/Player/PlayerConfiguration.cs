using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Configurations/PlayerConfiguration")]
public class PlayerConfiguration : ScriptableObject {

    [Header("Movement fields")]
    [SerializeField] private float speed = 3f;
    public float Speed => speed;

    [Header("Shoot fields")]
    [SerializeField] private float shootCadency = 0.5f;
    public float ShootCadency => shootCadency;
    [SerializeField] private BaseProjectile projectilePrefab;
    public BaseProjectile ProjectilePrefab => projectilePrefab;
}