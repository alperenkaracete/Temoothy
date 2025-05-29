using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;

public class WinLoseUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _winPopupGameobject;
    [SerializeField] private GameObject _losePopupGameobject;
    [SerializeField] private GameObject _blackBacgroundGameobject;
    [SerializeField] private TextMeshProUGUI _currentTimer;
    [SerializeField] private TextMeshProUGUI _winPopupTimer;
    [SerializeField] private TextMeshProUGUI _losePopupTimer;

    [Header("Settings")]
    [SerializeField] float _animationDuration;

    private Image _blackBackgroundImage;
    private RectTransform _losePopupRectTransform;
    private RectTransform _winPopupRectTransform;

    public event Action<string> OnGameWin;
    public event Action<string> OnGameLose;
    void Awake()
    {
        _blackBackgroundImage = _blackBacgroundGameobject.GetComponent<Image>();
        _losePopupRectTransform = _losePopupGameobject.GetComponent<RectTransform>();
        _winPopupRectTransform = _winPopupGameobject.GetComponent<RectTransform>();
    }
    void Start()
    {
        GameManager.Instance.OnGameOver += OnGameOver;
        HealthManager.Instance.OnPlayerDead += OnPlayerDead;

        _winPopupGameobject.transform.localScale = Vector3.zero;
        _losePopupGameobject.transform.localScale = Vector3.zero;
    }

    private void OnPlayerDead(GameState currentGameState)
    {
        if (HealthManager.Instance.PlayerCurrentHealth <= 0 && currentGameState == GameState.GameOver)
        {
            _blackBacgroundGameobject.SetActive(true);
            _losePopupGameobject.SetActive(true);
            OnGameLose?.Invoke(_currentTimer.text);
            _blackBackgroundImage?.DOFade(0.8f, _animationDuration)?.SetEase(Ease.Linear);
            _losePopupRectTransform?.DOScale(1.5f, _animationDuration)?.SetEase(Ease.OutBack);
        }
    }

    private void OnGameOver(int collectedEggs,GameState currentState)
    {
        int maxEggs = GameManager.Instance.MaxEggCount;

        if (maxEggs == collectedEggs && currentState == GameState.GameOver)
        {
            _blackBacgroundGameobject.SetActive(true);
            _winPopupGameobject.SetActive(true);
            OnGameWin?.Invoke(_currentTimer.text);
            _blackBackgroundImage?.DOFade(0.8f, _animationDuration)?.SetEase(Ease.Linear);
            _winPopupRectTransform?.DOScale(1.5f, _animationDuration)?.SetEase(Ease.OutBack);
        }
    }
}
