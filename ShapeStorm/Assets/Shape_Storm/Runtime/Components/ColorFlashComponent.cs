using System.Collections;
using UnityEngine;

public class ColorFlashComponent : MonoBehaviour
{
    [SerializeField] private Color _flashColor = Color.red;
    [SerializeField] private float _flashDuration = 0.15f;
    [SerializeField] private Renderer _renderer;

    private Color _initialColor;
    private Coroutine _flashCoroutine;
    private MaterialPropertyBlock _propertyBlock;

    private readonly int _baseColorID = Shader.PropertyToID("_BaseColor");

    void Awake()
    {
        if (!_renderer) _renderer = GetComponent<Renderer>();
        _propertyBlock = new MaterialPropertyBlock();
        _renderer.GetPropertyBlock(_propertyBlock);
        _initialColor = _renderer.sharedMaterial.GetColor(_baseColorID);
    }

    public void Flash()
    {
        if (_flashCoroutine != null) StopCoroutine(_flashCoroutine);
        _flashCoroutine = StartCoroutine(FlashCoroutine());
    }

    private IEnumerator FlashCoroutine()
    {
        float halfDuration = _flashDuration / 2;
        float elapsedTime = 0;

        while (elapsedTime < halfDuration)
        {
            SetColor(Color.Lerp(_initialColor, _flashColor, elapsedTime / halfDuration));
            yield return null;
            elapsedTime += Time.deltaTime;
        }

        SetColor(_flashColor);
        elapsedTime = 0f;

        while (elapsedTime < halfDuration)
        {
            SetColor(Color.Lerp(_flashColor, _initialColor, elapsedTime / halfDuration));
            yield return null;
            elapsedTime += Time.deltaTime;
        }

        SetColor(_initialColor);
    }

    private void SetColor(Color newColor)
    {
        _renderer.GetPropertyBlock(_propertyBlock);
        _propertyBlock.SetColor(_baseColorID, newColor);
        _renderer.SetPropertyBlock(_propertyBlock);
    }
}