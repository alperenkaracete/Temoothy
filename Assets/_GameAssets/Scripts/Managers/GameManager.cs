using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action<int> OnEggCollected;
    public static GameManager Instance { get; private set; }

    [SerializeField] private int maxEggCount = 5;

    private int _totalCollectedEggCount = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Sahnedeki fazla GameManager'ı sil
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Sahneler arasında yok olmasın (opsiyonel)
    }

    public void IncreaseTotalEggCount()
    {
        _totalCollectedEggCount += 1;
        OnEggCollected.Invoke(_totalCollectedEggCount);
        Debug.Log(_totalCollectedEggCount);
        if (_totalCollectedEggCount == maxEggCount)
        {
            Debug.Log("Game Win!");
        }
    }

    public int TotalCollectedEggCount => _totalCollectedEggCount;
    public int MaxEggCount => maxEggCount;
}
