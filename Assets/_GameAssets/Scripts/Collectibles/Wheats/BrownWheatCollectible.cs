using UnityEngine;

public class BrownWheatCollectible : MonoBehaviour,ICollectible
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private WheatDesignSO _brownWheatDesignSO; 

    public void Collect()
    {
        _playerController.ApplyBrownWheatEffects(_brownWheatDesignSO.IncreaseDecreaseAmount,_brownWheatDesignSO.Duration);
        Destroy(gameObject);
    }


}
