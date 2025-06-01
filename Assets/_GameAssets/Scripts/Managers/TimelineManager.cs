using System;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    private PlayableDirector _playableDirector;

    [Header("References")]
    [SerializeField] private StateController _playerStateController;

    void Awake()
    {
        _playableDirector = GetComponent<PlayableDirector>();
    }

    void OnEnable()
    {
        _playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(2.5);
        _playableDirector.Play();
        _playableDirector.stopped += OnTimelineFinish;
    }

    private void OnTimelineFinish(PlayableDirector director)
    {
        GameManager.Instance.ChangeGameState(GameState.Play);
        _playerStateController.SetPlayerState(PlayerState.Move);
    }
}
