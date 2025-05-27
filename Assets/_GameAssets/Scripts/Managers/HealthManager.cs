using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public event Action<int> OnPlayerGetsDamage;
    public event Action<int> OnPlayerGetsLife;
    public event Action OnPlayerInstantDead;

    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Damage(int damage)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damage;
            OnPlayerGetsDamage?.Invoke(_currentHealth);
        }
        
        if (_currentHealth == 0)
        {
            //Player Dead;
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
        OnPlayerInstantDead?.Invoke();
    }

    public int PlayerCurrentHealth => _currentHealth;
}
