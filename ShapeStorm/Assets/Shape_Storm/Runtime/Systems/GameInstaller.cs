using UnityEngine;

public class GameInstaller : MonoBehaviour {

    [SerializeField] private InputHandler inputHandler;

    private void OnEnable() {
        ServiceLocator.Instance.RegisterService(inputHandler);
    }

    void OnDisable() {
        ServiceLocator.Instance.UnregisterService<InputHandler>();
    }
}