using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _playerVisualTransform;
    private PlayerController _playerController;
    private Rigidbody _playerRigidbody;

    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerRigidbody = GetComponent<Rigidbody>();
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

    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.GiveDamage(_playerRigidbody, _playerVisualTransform);
        }
    }
}
