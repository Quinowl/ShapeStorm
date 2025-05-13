using UnityEngine;

public class WorldReferencesService : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    public Transform PlayerTransform => _playerTransform;
}