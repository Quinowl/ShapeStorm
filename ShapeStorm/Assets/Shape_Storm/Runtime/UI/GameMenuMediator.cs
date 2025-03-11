using UnityEngine;
using UnityEngine.EventSystems;

namespace ShapeStorm.Scripts.UI {
    public class GameMenuMediator : MonoBehaviour {

        [SerializeField] private EventSystem eventSystem;
        [SerializeField] private PauseView pauseView;

        private bool isPaused;

        void Awake() {
            isPaused = false;
        }

        public void UpdateEventSystemObject(GameObject _obj) => eventSystem.SetSelectedGameObject(_obj);

        private void TogglePause() {
            isPaused = !isPaused;
            GameManager.Instance.SetGameState(isPaused ? new PauseState() : new PlayingState());
        }
    }
}