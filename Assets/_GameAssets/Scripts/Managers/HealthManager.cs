using System;
using JetBrains.Annotations;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }
    public event Action<int> OnPlayerGetsDamage;
    public event Action<int> OnPlayerGetsLife;
    public event Action<GameState> OnPlayerInstantDead;
    public event Action<GameState> OnPlayerDead;

    [Header("References")]
    [SerializeField] private PlayerHealthUI _playerHealthUI;

    [Header("Settings")]
    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Damage(int damage)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damage;
            GameEffectManager.PlayShakeForDamage();
            OnPlayerGetsDamage?.Invoke(_currentHealth);
        }

        if (_currentHealth == 0)
        {
            GameManager.Instance.ChangeGameState(GameState.GameOver);
            OnPlayerDead?.Invoke(GameState.GameOver);
        }
    }

    public void Heal(int healAmount)
    {
        if (_currentHealth <= _maxHealth)
        {
            OnPlayerGetsLife?.Invoke(_currentHealth);
            _currentHealth += healAmount;
        }
    }

    public void InstantDead()
    {
        AudioManager.Instance.Play(SoundType.CatSound);
        GameManager.Instance.ChangeGameState(GameState.GameOver);
        GameEffectManager.PlayShakeForInstantDeath();
        OnPlayerInstantDead?.Invoke(GameState.GameOver);
        OnPlayerDead?.Invoke(GameState.GameOver);
    }

    public int PlayerCurrentHealth => _currentHealth;
}
