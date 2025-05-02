using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Shake Configuration")]
public class ShakeConfiguration : ScriptableObject
{
    [SerializeField] float _duration;
    public float Duration => _duration;
    [SerializeField] public float _intensity;
    public float Intensity => _intensity;
}