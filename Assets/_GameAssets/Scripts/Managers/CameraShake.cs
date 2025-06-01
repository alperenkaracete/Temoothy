using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }
    private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;
    private float _shakeTimer = 0;
    private float _shakeTimerTotal;
    private float _startingAmplitude;

    private void Awake()
    {
        Instance = this;
        _cinemachineBasicMultiChannelPerlin = GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Update()
    {
        if (_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime;
            if (_shakeTimer <= 0)
            {
                _cinemachineBasicMultiChannelPerlin.AmplitudeGain = Mathf.Lerp(_startingAmplitude, 0f, 1 - (_shakeTimer / _shakeTimerTotal));
            }
        }
    }

    public void HandleCameraShake(float amplitude, float shakeTime)
    {
        _cinemachineBasicMultiChannelPerlin.AmplitudeGain = amplitude;
        _shakeTimer = shakeTime;
        _shakeTimerTotal = _shakeTimer;
    }

}


