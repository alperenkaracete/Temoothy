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
    }
    private void ReplayLevel() {
        SceneManager.LoadScene(Others.GAME_SCENE);
    }
    private void OnGameLose(string currentClock)
    {
        _losePopupTimer.text = currentClock;
    }
}
