using UnityEngine;

public class EggCollectible : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    public void Collect()
    {
        AudioManager.Instance.Play(SoundType.PickupGoodSound);
        GameManager.Instance.IncreaseTotalEggCount();
        Destroy(gameObject);
    }
}
