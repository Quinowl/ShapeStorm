using UnityEngine;
using UnityEngine.EventSystems;

namespace ShapeStorm.Scripts.UI
{
    public class GameMenuMediator : MonoBehaviour
    {
        [SerializeField] private EventSystem _eventSystem;
        [SerializeField] private PauseView _pauseView;

        private bool isPaused;

        void Awake()
        {
            isPaused = false;
        }

        public void UpdateEventSystemObject(GameObject _obj) => _eventSystem.SetSelectedGameObject(_obj);

        private void TogglePause()
        {
            isPaused = !isPaused;
            GameManager.Instance.SetGameState(isPaused ? new PauseState() : new PlayingState());
        }
    }
}