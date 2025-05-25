using UnityEngine;

public class GreenWheatCollectible : MonoBehaviour,ICollectible
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _duration = 10;
   [SerializeField] private float _jumpSpeedMultiplier = 1.7f;

    public void Collect()
    {
        _playerController.ApplyGreenWheatEffects(_jumpSpeedMultiplier, _duration);
        Destroy(gameObject);
    }
}
