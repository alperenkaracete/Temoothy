using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControllerUI : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _howToPlayButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _exitButton;

    void Awake()
    {
        _startButton.onClick.AddListener(StartGame);
        _howToPlayButton.onClick.AddListener(HowToPlay);
        _creditsButton.onClick.AddListener(Credits);
        _exitButton.onClick.AddListener(ExitGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene(Others.GAME_SCENE);
    }

    void HowToPlay()
    {

    }

    void Credits()
    {

    }

    void ExitGame()
    {
        Application.Quit();
    }
    
}
