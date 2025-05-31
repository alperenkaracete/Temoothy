using MaskTransitions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePopupUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _losePopupTimer;
    [SerializeField] private WinLoseUI _winLoseUI;

    [Header("Buttons")]
    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _mainMenuButton;


    void Awake()
    {
        _winLoseUI.OnGameLose += OnGameLose;
    }
    void OnEnable()
    {
        _playAgainButton.onClick.AddListener(ReplayLevel);
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
    }
    private void OnMainMenuButtonClicked()
    {
        TransitionManager.Instance.LoadLevel(Others.MENU_SCENE);
    }

    private void ReplayLevel()
    {
        GameManager.Instance.ResetInstance();
        TransitionManager.Instance.LoadLevel(Others.GAME_SCENE);
    }
    private void OnGameLose(string currentClock)
    {
        _losePopupTimer.text = currentClock;
    }
}
