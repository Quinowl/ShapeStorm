using UnityEngine;
using UnityEngine.AI;

public class SpinnerEnemy : BaseEnemy
{
    [SerializeField] private NavMeshAgent _agent;
    private SpinnerEnemyConfiguration _spinnerConfiguration => _configuration as SpinnerEnemyConfiguration;
    private Transform _target;

    protected override void Start()
    {
        base.Start();
        if (!_target) _target = ServiceLocator.Instance.GetService<WorldReferencesService>().PlayerTransform;
    }

    protected override void UpdateStep()
    {
        base.UpdateStep();
        Rotate();
    }

    private void Rotate() => transform.Rotate(Vector3.up, _spinnerConfiguration.rotationSpeed * Time.deltaTime, Space.Self);
}