using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action<int> OnEggCollected;
    public event Action<GameState> OnGameStateChanged;
    public event Action<int,GameState> OnGameOver;
    public static GameManager Instance { get; private set; }
    private GameState _currentGameState;

    [SerializeField] private int maxEggCount = 5;

    private int _totalCollectedEggCount = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        //DontDestroyOnLoad(gameObject); // Sahneler arasında yok olmasın (opsiyonel)
    }

    void OnEnable()
    {
        ChangeGameState(GameState.Play);
    }

    public void ChangeGameState(GameState gameState)
    {
        _currentGameState = gameState;
        OnGameStateChanged?.Invoke(_currentGameState);
        Debug.Log((_currentGameState));
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
        ChangeGameState(GameState.Play);
        _totalCollectedEggCount = 0;
    }
    public int TotalCollectedEggCount => _totalCollectedEggCount;
    public int MaxEggCount => maxEggCount;
    public GameState CurrentGameState => _currentGameState;
}
