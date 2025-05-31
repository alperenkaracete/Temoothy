using UnityEngine.UI;
using UnityEngine;
using System;
using DG.Tweening;

public class PlayerHealthUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image[] _playerHealths;
    [SerializeField] private Sprite _playerHealthActive;
    [SerializeField] private Sprite _playerHealthInactive;
    [SerializeField] RectTransform[] _playerHealthTransforms;

    [Header("Settings")]
    [SerializeField] private float _scaleDuration;

    void Start()
    {
        HealthManager.Instance.OnPlayerGetsDamage += OnPlayerGetsDamage;
        HealthManager.Instance.OnPlayerGetsLife += OnPlayerGetsLife;
        HealthManager.Instance.OnPlayerInstantDead += OnPlayerInstantDead;
    }

    private void OnPlayerGetsLife(int currentHealth)
    {
        if (IsValidHealthIndex(currentHealth))
        {
            AnimateHealthChange(currentHealth, _playerHealthActive);
        }
    }

    private void OnPlayerGetsDamage(int currentHealth)
    {
        if (IsValidHealthIndex(currentHealth))
        {
            AnimateHealthChange(currentHealth, _playerHealthInactive);
        }
    }

    public void OnPlayerInstantDead(GameState currentGameState)
    {
        if (currentGameState == GameState.GameOver)
        {
            for (int i = 0; i < _playerHealths.Length; i++)
            {
                AnimateHealthChangeInstant(i, _playerHealthInactive);
            }
        }
    }
    public void AnimateHealthChangeInstant(int index, Sprite targetSprite)
    {
        _playerHealths[index].sprite = targetSprite;
    }
    public void AnimateHealthChange(int index, Sprite targetSprite)
    {
        RectTransform healthTransform = _playerHealthTransforms[index];

        healthTransform?.DOScale(0f, _scaleDuration)
            ?.SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                _playerHealths[index].sprite = targetSprite;
                healthTransform?.DOScale(1f, _scaleDuration)?.SetEase(Ease.OutBack);
            });
    }

    private bool IsValidHealthIndex(int index)
    {
        return index >= 0 && index < _playerHealths.Length;
    }
}
