using DG.Tweening;
using TMPro;
using UnityEngine;

public class EggCountUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _eggCount;
    private RectTransform _eggCounterRectTransform;

    [Header("Color")]
    [SerializeField] private Color _colorValue;
    [SerializeField] private float _colorDuration;
    [Header("Animation")]
    [SerializeField] private float _scaleDuration;
    [SerializeField] private Ease _ease;

    private int _maxEggCount;


    void Awake()
    {
        _eggCounterRectTransform = _eggCount.GetComponent<RectTransform>();
    }
    void Start()
    {
        GameManager.Instance.OnEggCollected += OnEggCollected;
        _maxEggCount = GameManager.Instance.MaxEggCount;
    }

    private void OnEggCollected(int eggCount)
    {
        string formattedText = $"{eggCount}/{_maxEggCount}";
        _eggCount.text = formattedText;
        if (eggCount == _maxEggCount)
        {
            AnimateEggCount();
            Debug.Log("Hello");
        }
    }

    private void AnimateEggCount()
    {
        _eggCount.DOColor(_colorValue, _colorDuration);
        _eggCounterRectTransform.DOScale(1.2f, _scaleDuration).SetEase(_ease);
    }
}
