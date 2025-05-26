using UnityEngine;

public class GoldWheatCollectible : MonoBehaviour,ICollectible
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private PlayerController _playerController;

    [SerializeField] private WheatDesignSO _goldWheatDesignSO; 

    public void Collect()
    {
        _playerController.ApplyGoldWheatEffects(_goldWheatDesignSO.IncreaseDecreaseAmount, _goldWheatDesignSO.Duration);
        Destroy(gameObject);
    }
}
