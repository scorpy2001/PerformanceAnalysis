using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace PerfomanceAnalysis
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _shopMenuButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Behaviour _shopCanvasComponent;
        [SerializeField] private Behaviour _mainMenuCanvasComponent;

        private void OnEnable()
        {
            _exitButton.onClick.AddListener(Exit);
            _shopMenuButton.onClick.AddListener(ActivateShop);
            _mainMenuButton.onClick.AddListener(ActivateMainMenu);
        }

        private void OnDisable()
        {
            _exitButton.onClick.RemoveAllListeners();
            _shopMenuButton.onClick.RemoveAllListeners();
            _mainMenuButton.onClick.RemoveAllListeners();
        }

        private void Exit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void ActivateShop(){
            _mainMenuCanvasComponent.enabled = false;
            _shopCanvasComponent.enabled = true;
        }

        private void ActivateMainMenu(){
            _shopCanvasComponent.enabled = false;
            _mainMenuCanvasComponent.enabled = true;
        }
    }
}
