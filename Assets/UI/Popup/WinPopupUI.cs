using System;
using MaskTransitions;
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
        BackgroundMusic.Instance.PlayBackgroundMusic(false);
        AudioManager.Instance.Play(SoundType.WinSound);
        _playAgainButton.onClick.AddListener(ReplayLevel);
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
    }

    private void OnMainMenuButtonClicked()
    {
        AudioManager.Instance.Play(SoundType.TransitionSound);
        TransitionManager.Instance.LoadLevel(Others.MENU_SCENE);
    }

    private void OnGameWin(string currentClock)
    {
        _winPopupTimer.text = currentClock;
    }
    private void ReplayLevel()
    {
        AudioManager.Instance.Play(SoundType.TransitionSound);
        GameManager.Instance.ResetInstance();
        TransitionManager.Instance.LoadLevel(Others.GAME_SCENE);
    }
}
