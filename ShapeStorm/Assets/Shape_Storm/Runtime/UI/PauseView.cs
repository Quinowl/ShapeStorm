using UnityEngine;
using UnityEngine.UI;

namespace ShapeStorm.Scripts.UI {
    public class PauseView : MonoBehaviour {

        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button menuButton;

        private GameMenuMediator mediator;

        void Start() => InitializeButtons();

        public void Configure(GameMenuMediator _menuMediator) => mediator = _menuMediator;

        public void Show() {
            canvasGroup.Toggle(true);
            mediator.UpdateEventSystemObject(resumeButton.gameObject);
        }

        public void Hide() => canvasGroup.Toggle(false);

        private void InitializeButtons() {
            resumeButton.onClick.RemoveAllListeners();
            settingsButton.onClick.RemoveAllListeners();
            menuButton.onClick.RemoveAllListeners();
        }

        private void OnResumeButton() {

        }

        private void OnSettingsButton() {

        }

        private void OnMenuButton() {

        }
    }
}