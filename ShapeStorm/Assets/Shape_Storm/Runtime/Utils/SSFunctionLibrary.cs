using UnityEngine;

public static class SSFunctionLibrary
{
    public static void Toggle(this CanvasGroup _canvasGroup, bool _enable)
    {
        _canvasGroup.alpha = _enable ? 1f : 0f;
        _canvasGroup.blocksRaycasts = _enable;
        _canvasGroup.interactable = _enable;
    }
}