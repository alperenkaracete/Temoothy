using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBuffsDebuffsUI : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite _speedBuffActiveSprite;
    [SerializeField] private Sprite _speedBuffDeactiveSprite;
    [SerializeField] private Sprite _goldWheatSprite;
    [SerializeField] private Sprite _jumpBuffActiveSprite;
    [SerializeField] private Sprite _jumpBuffDeactiveSprite;
    [SerializeField] private Sprite _greenWheatSprite;
    [SerializeField] private Sprite _speedDebuffActiveSprite;
    [SerializeField] private Sprite _speedDebuffDeactiveSprite;
    [SerializeField] private Sprite _brownWheatSprite;
    [SerializeField] private Sprite _deactiveWheatSprite;

    [Header("References")]
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private RectTransform _speedBuffRect;
    [SerializeField] private RectTransform _jumpBuffRect;
    [SerializeField] private RectTransform _speedDebuffRect;
    [SerializeField] private RectTransform _goldWheatRect;
    [SerializeField] private RectTransform _greenWheatRect;
    [SerializeField] private RectTransform _brownWheatRect;

    [Header("Settings")]
    [SerializeField] private float _moveDuration;
    [SerializeField] private Ease _moveEase;

    private Image _speedBuffImage, _jumpBuffImage, _speedDebuffImage;
    private Image _goldWheatImage, _greenWheatImage, _brownWheatImage;

    void Start()
    {
        _playerController.OnPlayerCollectWheat += OnPlayerCollectWheat;

        _speedBuffImage = _speedBuffRect.GetComponent<Image>();
        _jumpBuffImage = _jumpBuffRect.GetComponent<Image>();
        _speedDebuffImage = _speedDebuffRect.GetComponent<Image>();
        _goldWheatImage = _goldWheatRect.GetComponent<Image>();
        _greenWheatImage = _greenWheatRect.GetComponent<Image>();
        _brownWheatImage = _brownWheatRect.GetComponent<Image>();
    }

    private void OnPlayerCollectWheat(string wheat, float duration)
    {
        switch (wheat)
        {
            case WheatTypes.GOLD_WHEAT:
                SetBuffActive(_speedBuffRect, _speedBuffImage, _goldWheatImage, _speedBuffActiveSprite, _goldWheatSprite);
                StartCoroutine(ResetBuffAfterDelay(_speedBuffRect, _speedBuffImage, _goldWheatImage, _speedBuffDeactiveSprite, _deactiveWheatSprite, duration));
                break;

            case WheatTypes.BROWN_WHEAT:
                SetBuffActive(_speedDebuffRect, _speedDebuffImage, _brownWheatImage, _speedDebuffActiveSprite, _brownWheatSprite);
                StartCoroutine(ResetBuffAfterDelay(_speedDebuffRect, _speedDebuffImage, _brownWheatImage, _speedDebuffDeactiveSprite, _deactiveWheatSprite, duration));
                break;

            case WheatTypes.GREEN_WHEAT:
                SetBuffActive(_jumpBuffRect, _jumpBuffImage, _greenWheatImage, _jumpBuffActiveSprite, _greenWheatSprite);
                StartCoroutine(ResetBuffAfterDelay(_jumpBuffRect, _jumpBuffImage, _greenWheatImage, _jumpBuffDeactiveSprite, _deactiveWheatSprite, duration));
                break;
        }
    }

    void SetBuffActive(RectTransform buffRect, Image buffImage, Image wheatImage, Sprite buffSprite, Sprite wheatSprite)
    {
        buffImage.sprite = buffSprite;
        wheatImage.sprite = wheatSprite;
        buffRect.DOAnchorPosX(-25f, _moveDuration).SetEase(_moveEase);
    }

    IEnumerator ResetBuffAfterDelay(RectTransform buffRect, Image buffImage, Image wheatImage, Sprite buffSprite, Sprite wheatSprite, float delay)
    {
        yield return new WaitForSeconds(delay);
        buffImage.sprite = buffSprite;
        wheatImage.sprite = wheatSprite;
        buffRect.DOAnchorPosX(0f, _moveDuration).SetEase(_moveEase);
    }
}
