using UnityEngine;

public interface IDamageable
{
    public void GiveDamage(Rigidbody playerControllerRigidBody, Transform playerControllerTransform);
}
