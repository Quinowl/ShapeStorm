using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShakeComponent : MonoBehaviour
{
    [SerializeField, Tooltip("Objeto que sufrirá el shake")] private Transform shakeObject;
    [SerializeField] private ShakeConfiguration _shakeConfiguration;
    private Vector3 _startPosition;
    
    public bool IsShaking { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) Activate();
    }

    public void Activate()
    {
        _startPosition = transform.localPosition;
        if (!IsShaking) StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        IsShaking = true;
        float timeElapsed = 0f;
        while (timeElapsed < _shakeConfiguration.Duration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * _shakeConfiguration.Intensity;
            transform.localPosition = _startPosition + randomOffset;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = _startPosition;
        IsShaking = false;
    }
}