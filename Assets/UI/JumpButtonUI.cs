using System;
using UnityEngine;
using UnityEngine.UI;

public class JumpButtonUI : MonoBehaviour
{
    [SerializeField] private Button _jumpButton;

    public event Action OnPlayerJump;
    void Awake()
    {
        _jumpButton.onClick.AddListener(PlayerJump);
    }

    private void PlayerJump()
    {
        OnPlayerJump.Invoke();
    }
}
