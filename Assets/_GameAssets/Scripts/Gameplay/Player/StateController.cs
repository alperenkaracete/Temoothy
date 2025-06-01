using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StateController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private PlayerState _currentPlayerState;
    void Start()
    {
        _currentPlayerState = PlayerState.Watching;
    }

    public void SetPlayerState(PlayerState newPlayerState)
    {
        if (newPlayerState != _currentPlayerState)
        {
            _currentPlayerState = newPlayerState;
        }
    }

    public PlayerState GetPlayerState()
    {
        return _currentPlayerState;
    }

}
