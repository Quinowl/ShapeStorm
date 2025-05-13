using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Configurations/Enemies/Spinner")]
public class SpinnerEnemyConfiguration : BaseEnemyConfiguration
{
    [Header("Spinner fields")]
    public float moveSpeed = 3f;
    public float rotationSpeed = 5f;
    public float stoppingDistance = 10f;
}