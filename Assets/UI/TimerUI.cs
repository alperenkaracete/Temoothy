using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform _timerRotatableTransform;
    [SerializeField] private TMP_Text _timerText;

    [Header("Timer Settings")]
    [SerializeField] private float _timer;
    [SerializeField] private Ease _rotationEase;

    private float _elapsedTime;

    void Start()
    {
        PlayRotationAnimation();
        StartTimer();
    }

    private void PlayRotationAnimation()
    {
        Vector3 _rotateDirection = new Vector3(0f, 0f, -360f);
        _timerRotatableTransform.DORotate(_rotateDirection, _timer, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(_rotationEase);
    }

    private void StartTimer()
    {
        _elapsedTime = 0.0f;
        InvokeRepeating(nameof(UpdateTimerUI), 0f, 1f);
    }

    private void UpdateTimerUI()
    {

        _elapsedTime += 1f;

        int minutes = Mathf.FloorToInt(_elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(_elapsedTime % 60f);

        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
