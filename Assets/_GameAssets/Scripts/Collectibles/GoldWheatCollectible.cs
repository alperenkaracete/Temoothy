using UnityEngine;

public class GoldWheatCollectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private PlayerController _playerController;

    [SerializeField] private float _duration = 10;
    [SerializeField] private float _movementSpeedBuff = 10;

    public void Collect()
    {
        _playerController.ApplyGoldWheatEffects(_movementSpeedBuff, _duration);
        Destroy(gameObject);
    }
}
