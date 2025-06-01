using UnityEngine;

public class GreenWheatCollectible : MonoBehaviour,ICollectible
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private WheatDesignSO _greenWheatDesignSO; 

    public void Collect()
    {
        AudioManager.Instance.Play(SoundType.PickupGoodSound);
        _playerController.ApplyGreenWheatEffects(_greenWheatDesignSO.IncreaseDecreaseAmount, _greenWheatDesignSO.Duration);
        Destroy(gameObject);
    }
}
