using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActionsUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform _playerWalkingTransform;
    [SerializeField] private RectTransform _playerSlidingTransform;
    [SerializeField] private PlayerController _playerController;

    [Header("Sprites")]
    [SerializeField] private Sprite _playerWalkingPassiveSprite;
    [SerializeField] private Sprite _playerWalkingActiveSprite;
    [SerializeField] private Sprite _playerSlidingPassiveSprite;
    [SerializeField] private Sprite _playerSlidingActiveSprite;

    [Header("Settings")]
    [SerializeField] private float _moveDuration;
    [SerializeField] private Ease _moveEase;

    private Image _playerMovingImage;
    private Image _playerSlidingImage;

    void Awake()
    {
        _playerMovingImage = _playerWalkingTransform.GetComponent<Image>();
        _playerSlidingImage = _playerSlidingTransform.GetComponent<Image>();
        _playerController.OnPlayerStateChanged += PlayerController_OnPlayerStateChanged;
    }

    void Start()
    {
        _playerMovingImage.sprite = _playerWalkingPassiveSprite;
        _playerSlidingImage.sprite = _playerSlidingPassiveSprite;
    }

    private void PlayerController_OnPlayerStateChanged(PlayerState playerState)
    {
        switch (playerState)
        {
            case PlayerState.Watching:
                break;
            case PlayerState.Idle:
            case PlayerState.Move:
                SetStateUserInterfaces(_playerWalkingActiveSprite, _playerSlidingPassiveSprite, _playerWalkingTransform, _playerSlidingTransform);
                break;

            case PlayerState.Slide:
            case PlayerState.SlideIdle:
                SetStateUserInterfaces(_playerWalkingPassiveSprite, _playerSlidingActiveSprite, _playerSlidingTransform, _playerWalkingTransform);
                break;
        }
    }

    private void SetStateUserInterfaces(Sprite playerWalkingSprite, Sprite playerSlidingSprite, RectTransform activeTransform, RectTransform passiveTransform)
    {

        _playerMovingImage.sprite = playerWalkingSprite;
        _playerSlidingImage.sprite = playerSlidingSprite;
        
        activeTransform.DOAnchorPosX(25f, _moveDuration).SetEase(_moveEase);
        passiveTransform.DOAnchorPosX(0f, _moveDuration).SetEase(_moveEase);
        
    }
}
