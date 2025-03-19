using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    [SerializeField] private PanelType _panelType;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartGame);
        _mainMenuButton.onClick.AddListener(BackToMainMenu);
    }

    private void RestartGame() => SceneManager.LoadScene(1);

    private void BackToMainMenu() => SceneManager.LoadScene(0);

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartGame);
        _mainMenuButton.onClick.RemoveListener(BackToMainMenu);
    }

    public PanelType GetPanelType() => _panelType;
}
