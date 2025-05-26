using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class SpatulaBooster : MonoBehaviour, IBoostable
{
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private Animator _spatulaAnimator;
    [SerializeField] private float duration;
    private bool _playerIsOnSpatula = false;


    public void Boost(PlayerController playerController)
    {
        if (_playerIsOnSpatula)
            return;
        Rigidbody playerRigidBody = playerController.GetPlayerRigidBody();
        playerRigidBody.linearVelocity = new Vector3(playerRigidBody.linearVelocity.x, 0f, playerRigidBody.linearVelocity.z);
        playerRigidBody.AddForce(transform.forward * -_jumpSpeed, ForceMode.Impulse);
        _playerIsOnSpatula = true;
        AnimateSpatula();
        Invoke("ResetSpatula", duration);
    }

    void AnimateSpatula()
    {
        if (_playerIsOnSpatula)
            _spatulaAnimator.SetTrigger(Others.SPATULA_STATE);
    }

    void ResetSpatula()
    {
        _playerIsOnSpatula = false;
    }
}
