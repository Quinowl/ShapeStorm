using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShakeComponent : MonoBehaviour
{
    [SerializeField, Tooltip("Objeto que sufrirá el shake")] private Transform shakeObject;
    [SerializeField] private ShakeConfiguration _shakeConfiguration;
    private Vector3 _startPosition;
    private bool _isShaking;

    public void Activate()
    {
        _startPosition = transform.localPosition;
        if (!_isShaking) StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        _isShaking = true;
        float timeElapsed = 0f;
        while (timeElapsed < _shakeConfiguration.duration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * _shakeConfiguration.intensity;
            transform.localPosition = _startPosition + randomOffset;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = _startPosition;
        _isShaking = false;
    }
}