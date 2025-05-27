using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<PlayerState> OnPlayerStateChanged;
    public event Action<string,float> OnPlayerCollectWheat;
    private Rigidbody _rigidBody;

    [Header("References")]
    [SerializeField] private Transform _orientationTransform;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private PlayerState _state;

    [Header("Movement")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private KeyCode _moveActivateKey;

    [Header("Jumping")]
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private KeyCode _jumpingKey;

    [Header("Ground Settings")]
    [SerializeField] private float _playerHeight;
    [SerializeField] private LayerMask _groundLayer;

    [Header("Slide Options")]
    [SerializeField] private float _slideSpeed;
    [SerializeField] private KeyCode _slideActivateKey;

    [Header("Player")]
    [SerializeField] private HealthManager _playerHealthManager;

    private Vector3 _movementDirection;
    private StateController _currentState;
    private bool isSliding = false;
    private float _startingMovementSpeed, _startingSlideSpeed, _startingJumpSpeed;

    private float _horizantolInput, _verticalInput;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _currentState = GetComponent<StateController>();
        _currentState.SetPlayerState(PlayerState.Move);
        _rigidBody.freezeRotation = true;
        _currentSpeed = _movementSpeed;
        _startingMovementSpeed = _movementSpeed;
        _startingSlideSpeed = _slideSpeed;
        _startingJumpSpeed = _jumpSpeed;
    }

    void Start()
    {
        OnPlayerStateChanged?.Invoke(PlayerState.Idle);
    }

    void Update()
    {
        SetInputs();
        SetState();
        SetMovementSpeed();
        LimitPlayerSpeed();
    }

    private void SetMovementSpeed()
    {
        if (_state == PlayerState.Idle)
            _currentSpeed = 0;

        else if (_state == PlayerState.Move)
            _currentSpeed = _movementSpeed;

        else if (_state == PlayerState.Slide)
            _currentSpeed = _slideSpeed;
    }

    void FixedUpdate()
    {
        SetMovement();
    }

    void SetInputs()
    {
        _horizantolInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(_jumpingKey))
        {
            if (IsGrounded())
                SetJumping();
        }

        if (Input.GetKeyDown(_slideActivateKey))
        {
            isSliding = true;
        }

        else if (Input.GetKeyDown(_moveActivateKey))
        {
            isSliding = false;
        }
    }

    void SetState()
    {
        PlayerState newState = _currentState.GetPlayerState();
        Vector3 movementDirectionNormalized = _movementDirection.normalized;
        bool isGrounded = IsGrounded();
        if (movementDirectionNormalized != Vector3.zero && isGrounded && !isSliding)
            newState = PlayerState.Move;
        else if (movementDirectionNormalized != Vector3.zero && isGrounded && isSliding)
            newState = PlayerState.Slide;
        else if (movementDirectionNormalized == Vector3.zero && isGrounded && !isSliding)
            newState = PlayerState.Idle;
        else if (movementDirectionNormalized == Vector3.zero && isGrounded && isSliding)
            newState = PlayerState.SlideIdle;
        else if (!isGrounded)
            newState = PlayerState.Jump;


        if (_currentState.GetPlayerState() != newState)
        {
            _currentState.SetPlayerState(newState);
            _state = newState;
            OnPlayerStateChanged?.Invoke(newState);
            /*if (_currentState.GetPlayerState() == PlayerState.Jump) //HealthManagerControl
                _playerHealthManager.Damage(1);
            else if (_currentState.GetPlayerState() == PlayerState.Slide)
                _playerHealthManager.InstantDead();    */
        }
    }

    void SetMovement()
    {
        _movementDirection = _orientationTransform.forward * _verticalInput + _orientationTransform.right * _horizantolInput;
        //Eğer burada normalized değil de sadece movement direction kullanılırsa, mesela çapraz gidildiği zaman pisagor alarak daha hızlı ilerler.Bu yüzden normalized alıyoruz ki sağa,sola ve yukarı,aşağı gittiği hıza eşit bir şekilde çapraz da gitsin.
        float airMultiplier = IsGrounded() ? 1f : 1f;
        _rigidBody.AddForce(_movementDirection.normalized * _currentSpeed * airMultiplier, ForceMode.Force);
    }

    void LimitPlayerSpeed()
    {
        Vector3 flatVelocity = new Vector3(_rigidBody.linearVelocity.x, 0f, _rigidBody.linearVelocity.z);

        if (flatVelocity.magnitude > _movementSpeed)
        {

            Vector3 limitedVelocity = flatVelocity.normalized * _movementSpeed;
            _rigidBody.linearVelocity = new Vector3(limitedVelocity.x, _rigidBody.linearVelocity.y, limitedVelocity.z);
        }
    }

    void SetJumping()
    {

        _rigidBody.linearVelocity = new Vector3(_rigidBody.linearVelocity.x, 0f, _rigidBody.linearVelocity.z);
        //Burda Impulse kullanıyoruz çünkü ani bir güç uygular, force süreli bir güç uygular.
        _rigidBody.AddForce(transform.up * _jumpSpeed, ForceMode.Impulse);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.5f + 0.2f, _groundLayer);
    }

    public float GetCurrentSpeed()
    {
        return _currentSpeed;
    }

    public void ApplyGoldWheatEffects(float movementSpeedBuff, float duration)
    {
        _movementSpeed += movementSpeedBuff;
        _slideSpeed += movementSpeedBuff;
        OnPlayerCollectWheat?.Invoke(WheatTypes.GOLD_WHEAT,duration);
        Invoke(nameof(ResetWheatEffect), duration);
    }

    public void ApplyBrownWheatEffects(float movementSpeedDebuff, float duration)
    {
        _slideSpeed -= movementSpeedDebuff;
        _movementSpeed -= movementSpeedDebuff;
        OnPlayerCollectWheat?.Invoke(WheatTypes.BROWN_WHEAT,duration);
        Invoke(nameof(ResetWheatEffect), duration);
    }

    public void ApplyGreenWheatEffects(float jumpSpeedMultiplier, float duration)
    {
        _jumpSpeed *= jumpSpeedMultiplier;
        OnPlayerCollectWheat?.Invoke(WheatTypes.GREEN_WHEAT,duration);
        Invoke(nameof(ResetWheatEffect), duration);
    }

    void ResetWheatEffect()
    {
        if (_movementSpeed != _startingMovementSpeed)
            _movementSpeed = _startingMovementSpeed;
        if (_slideSpeed != _startingSlideSpeed)
            _slideSpeed = _startingSlideSpeed;
        else if (_jumpSpeed != _startingJumpSpeed)
            _jumpSpeed = _startingJumpSpeed;
    }

    public Rigidbody GetPlayerRigidBody()
    {

        return _rigidBody;
    }
}
