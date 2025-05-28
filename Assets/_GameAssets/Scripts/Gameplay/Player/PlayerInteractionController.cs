using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    private PlayerController _playerController;

    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ICollectible>(out var wheatCollectible))
        {
            wheatCollectible.Collect();
        }
        if (other.TryGetComponent<EggCollectible>(out var eggCollectible))
        {
            eggCollectible.Collect();
        }
    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.TryGetComponent<IBoostable>(out var wheatCollectible))
        {
            wheatCollectible.Boost(_playerController);
        }
    }
}
