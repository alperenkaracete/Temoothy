using System;
using UnityEngine;
using UnityEngine.UI;

public class MusicSettingsUI : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite _musicActiveSprite;
    [SerializeField] private Sprite _musicPassiveSprite;
    private Image _musicButtonImage;
    private Button _musicButton;
    private bool _isMusicOn = true;
    void Awake()
    {
        _musicButtonImage = GetComponent<Image>();
        _musicButton = GetComponent<Button>();
        _musicButton.onClick.AddListener(HandleMusic);
    }

    private void HandleMusic()
    {
        if (_isMusicOn)
        {
            AudioManager.Instance.Play(SoundType.ButtonClickSound);
            _isMusicOn = false;
            BackgroundMusic.Instance.SetMusicMute(true);
            _musicButtonImage.sprite = _musicPassiveSprite;
        }
        else if (!_isMusicOn)
        {
            AudioManager.Instance.Play(SoundType.ButtonClickSound);
            _isMusicOn = true;
            BackgroundMusic.Instance.SetMusicMute(false);
            _musicButtonImage.sprite = _musicActiveSprite;
        }
    }
}
