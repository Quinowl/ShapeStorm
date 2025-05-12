using UnityEngine;
using UnityEngine.UI;

namespace ShapeStorm.Scripts.UI
{
    public class PauseView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _menuButton;

        private GameMenuMediator _mediator;

        void Start() => InitializeButtons();

        public void Configure(GameMenuMediator _menuMediator) => _mediator = _menuMediator;

        public void Show()
        {
            _canvasGroup.Toggle(true);
            _mediator.UpdateEventSystemObject(_resumeButton.gameObject);
        }

        public void Hide() => _canvasGroup.Toggle(false);

        private void InitializeButtons()
        {
            _resumeButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
            _menuButton.onClick.RemoveAllListeners();
        }

        private void OnResumeButton()
        {

        }

        private void OnSettingsButton()
        {

        }

        private void OnMenuButton()
        {

        }
    }
}