using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Camera Configuration")]
public class CameraConfiguration : ScriptableObject
{
    public float speed = 5f;
    public Vector3 offset = new Vector3(0, 10, -10);
    public float fovChangeSmoothTime = 0.4f;
    public int baseFOV = 60;
    public int maxFOV = 70;
}