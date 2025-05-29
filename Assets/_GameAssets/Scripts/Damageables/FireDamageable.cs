using UnityEngine;

public class FireDamageable : MonoBehaviour, IDamageable
{    
    [Header("Settings")]
    [SerializeField] private int _damageAmount = 1;
    [SerializeField] private float _force = 10;
    public void GiveDamage(Rigidbody playerControllerRigidBody, Transform playerVisualTransform)
    {
        HealthManager.Instance.Damage(_damageAmount);
        playerControllerRigidBody.AddForce(-playerVisualTransform.forward * _force, ForceMode.Impulse);
        Destroy(gameObject);
    }
}
