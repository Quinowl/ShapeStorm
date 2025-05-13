using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Camera Configuration")]
public class CameraConfiguration : ScriptableObject
{
    public Vector3 offset = new Vector3(0, 10, -10);
    public float followSmoothTime = 0.1f;
    public float zoomOutAmount = 10f;
    public float zoomSmoothSpeed = 4f;
}