using UnityEngine;

public static class SSFunctionLibrary
{
    public static void Toggle(this CanvasGroup canvasGroup, bool enable)
    {
        canvasGroup.alpha = enable ? 1f : 0f;
        canvasGroup.blocksRaycasts = enable;
        canvasGroup.interactable = enable;
    }
}