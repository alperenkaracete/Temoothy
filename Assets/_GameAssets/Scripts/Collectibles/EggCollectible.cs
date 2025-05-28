using UnityEngine;

public class EggCollectible : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    public void Collect()
    {
        GameManager.Instance.IncreaseTotalEggCount();
        Destroy(gameObject);
    }
}
