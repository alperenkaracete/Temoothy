using System;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action<int> OnEggCollected;
    public event Action<GameState> OnGameStateChanged;
    public event Action<int,GameState> OnGameOver;
    public static GameManager Instance { get; private set; }
    private GameState _currentGameState;

    [Header("Game Settings")]
    [SerializeField] public GamePlatform _gamePlatform;
    [SerializeField] private int maxEggCount = 5;
    [SerializeField] private JumpButtonUI _jumpButtonUI;
    [SerializeField] private FixedJoystick _fixedJoystick;

    private int _totalCollectedEggCount = 0;

    private void Awake()
    {
        Instance = this;
        if (Instance._gamePlatform == GamePlatform.Pc)
        {
            if (_fixedJoystick != null) _fixedJoystick.gameObject.SetActive(false);
            if (_jumpButtonUI != null) _jumpButtonUI.gameObject.SetActive(false);
        }
        else if (Instance._gamePlatform == GamePlatform.Android)
        {
            if (_fixedJoystick != null) _fixedJoystick.gameObject.SetActive(true);
            if (_jumpButtonUI != null) _jumpButtonUI.gameObject.SetActive(true);
        }
    }

    void OnEnable()
    {
        ChangeGameState(GameState.CutScene);
        BackgroundMusic.Instance?.PlayBackgroundMusic(true);
    }

    public void ChangeGameState(GameState gameState)
    {
        _currentGameState = gameState;
        OnGameStateChanged?.Invoke(_currentGameState);
    }

    public void IncreaseTotalEggCount()
    {
        _totalCollectedEggCount += 1;
        OnEggCollected.Invoke(_totalCollectedEggCount);
        Debug.Log(_totalCollectedEggCount);
        if (_totalCollectedEggCount == maxEggCount)
        {
            Debug.Log("Game Win!");
            ChangeGameState(GameState.GameOver);
            OnGameOver.Invoke(_totalCollectedEggCount,GameState.GameOver);
        }
    }
    public void ResetInstance()
    {
        DOTween.KillAll();
        ChangeGameState(GameState.Play);
        _totalCollectedEggCount = 0;
    }
    public int TotalCollectedEggCount => _totalCollectedEggCount;
    public void SetTotalCollectedEggCount(int eggCount)
    {
        _totalCollectedEggCount = eggCount;
    }
    public int MaxEggCount => maxEggCount;
    public GameState CurrentGameState => _currentGameState;
}
