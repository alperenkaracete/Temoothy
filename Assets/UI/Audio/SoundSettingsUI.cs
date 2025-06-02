using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettingsUI : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite _soundActiveSprite;
    [SerializeField] private Sprite _soundPassiveSprite;
    private Image _soundButtonImage;
    private Button _soundButton;
    private bool _isSoundOn = true;
    void Awake()
    {
        _soundButtonImage = GetComponent<Image>();
        _soundButton = GetComponent<Button>();
        _soundButton.onClick.AddListener(HandleSound);
    }

    private void HandleSound()
    {
        if (_isSoundOn)
        {
            AudioManager.Instance.Play(SoundType.ButtonClickSound);
            _isSoundOn = false;
            AudioManager.Instance.SetSoundEffectsMute(true);
            _soundButtonImage.sprite = _soundPassiveSprite;
        }
        else if (!_isSoundOn)
        {
            AudioManager.Instance.Play(SoundType.ButtonClickSound);
            _isSoundOn = true;
            AudioManager.Instance.SetSoundEffectsMute(true);
            _soundButtonImage.sprite = _soundActiveSprite;
        }
    }
}
