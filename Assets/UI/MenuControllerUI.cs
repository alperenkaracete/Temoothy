using System;
using System.Runtime.CompilerServices;
using MaskTransitions;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControllerUI : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _howToPlayButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _returnMainMenuButton;
    [SerializeField] private Image _howToPlayPopup;
    [SerializeField] private Image _creditsPopup;

    void Awake()
    {
        _startButton.onClick.AddListener(StartGame);
        _howToPlayButton.onClick.AddListener(HowToPlay);
        _creditsButton.onClick.AddListener(Credits);
        _exitButton.onClick.AddListener(ExitGame);
        _returnMainMenuButton.onClick.AddListener(ReturnMainMenu);
    }

    private void ReturnMainMenu()
    {
        AudioManager.Instance.Play(SoundType.TransitionSound);
        if (_howToPlayPopup.IsActive())
            _howToPlayPopup.gameObject.SetActive(false);
        else if (_creditsPopup.IsActive())
            _creditsPopup.gameObject.SetActive(false);            
        _returnMainMenuButton.gameObject.SetActive(false);
        
    }

    void StartGame()
    {
        AudioManager.Instance.Play(SoundType.TransitionSound);
        TransitionManager.Instance.LoadLevel(Others.GAME_SCENE);
    }

    void HowToPlay()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
        _howToPlayPopup.gameObject.SetActive(true);
        _returnMainMenuButton.gameObject.SetActive(true);
    }

    void Credits()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
        _creditsPopup.gameObject.SetActive(true);
        _returnMainMenuButton.gameObject.SetActive(true);

    }

    void ExitGame()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
        Application.Quit();
    }
    
}
