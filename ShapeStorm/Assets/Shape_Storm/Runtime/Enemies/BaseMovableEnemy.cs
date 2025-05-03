using UnityEngine;
using UnityEngine.AI;

public class BaseMovableEnemy : BaseEnemy
{
    [SerializeField] private NavMeshAgent _agent;
    
    protected virtual void Move()
    {
        // Movimiento kinemático? Usamos el nav mesh mejor al ser enemigos
    }
}