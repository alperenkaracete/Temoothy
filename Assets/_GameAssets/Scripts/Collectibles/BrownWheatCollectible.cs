using UnityEngine;

public class BrownWheatCollectible : MonoBehaviour,ICollectible
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _duration = 10;
    [SerializeField] private float _movementSpeedDebuff = 20;

    public void Collect()
    {
        _playerController.ApplyBrownWheatEffects(_movementSpeedDebuff, _duration);
        Destroy(gameObject);
    }


}
