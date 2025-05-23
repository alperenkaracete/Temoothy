using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;
    private PlayerController _playerController;
    private StateController _stateController;

    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _stateController = GetComponent<StateController>();
    }

    void Update()
    {
        SetPlayerAnimations();
    }

    private void SetPlayerAnimations()
    {

        PlayerState currentPlayerState;

        currentPlayerState = _stateController.GetPlayerState();

        if (currentPlayerState == PlayerState.Idle)
        {
            _playerAnimator.SetBool(ActionTypes.MOVE, false);
            _playerAnimator.SetBool(ActionTypes.SLIDE, false);
            _playerAnimator.SetBool(ActionTypes.JUMP, false);
        }
        else if (currentPlayerState == PlayerState.Move)
        {
            _playerAnimator.SetBool(ActionTypes.JUMP, false);
            _playerAnimator.SetBool(ActionTypes.SLIDE, false);
            _playerAnimator.SetBool(ActionTypes.MOVE, true);
        }
        else if (currentPlayerState == PlayerState.Slide)
        {
            _playerAnimator.SetBool(ActionTypes.SLIDE, true);
            _playerAnimator.SetBool(ActionTypes.SLIDE_START, true);
        }
        else if (currentPlayerState == PlayerState.SlideIdle)
        {
            _playerAnimator.SetBool(ActionTypes.SLIDE_START, false);
            _playerAnimator.SetBool(ActionTypes.SLIDE, true);
        }
        else if (currentPlayerState == PlayerState.Jump && _playerController.GetCurrentSpeed() != 0)
        {
            _playerAnimator.SetBool(ActionTypes.MOVE, true);
            _playerAnimator.SetBool(ActionTypes.JUMP, true);
        }
        else if (currentPlayerState == PlayerState.Jump)
        {
            _playerAnimator.SetBool(ActionTypes.JUMP, true);
            _playerAnimator.SetBool(ActionTypes.MOVE, false);
        }       
        
    }
}
