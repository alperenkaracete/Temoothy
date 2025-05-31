using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPopupUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _winPopupTimer;
    [SerializeField] private WinLoseUI _winLoseUI;

    [Header("Buttons")]
    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _mainMenuButton;

    void Awake()
    {
        _winLoseUI.OnGameWin += OnGameWin;
    }

    void OnEnable()
    {
        _playAgainButton.onClick.AddListener(ReplayLevel);
    }
    private void OnGameWin(string currentClock)
    {
        _winPopupTimer.text = currentClock;
    }
    private void ReplayLevel() {
        GameManager.Instance.ResetInstance();
        SceneManager.LoadScene(Others.GAME_SCENE);
    }
}
