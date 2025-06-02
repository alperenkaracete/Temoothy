using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _playerVisualTransform;
    [SerializeField] private Transform _orientationTransform;
    [SerializeField] private FixedJoystick _fixedJoystick;

    [Header("Rotation")]
    [SerializeField] private float _rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentGameState != GameState.Resume && GameManager.Instance.CurrentGameState != GameState.Play)
        {
            return;
        }
        Vector3 viewDirection = _playerTransform.position - new Vector3(transform.position.x, _playerTransform.position.y, transform.position.z);
        Vector3 inputDirection = Vector3.zero;
        float horizontalInput = 0;
        float verticalInput = 0;
        if (GameManager.Instance._gamePlatform == GamePlatform.Pc)
        {
            _orientationTransform.forward = viewDirection.normalized;
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }
        else if (GameManager.Instance._gamePlatform == GamePlatform.Android)
        {
            _orientationTransform.forward = viewDirection.normalized;
            horizontalInput = _fixedJoystick.Horizontal;
            verticalInput = _fixedJoystick.Vertical;
            
        }        
        inputDirection = _orientationTransform.forward * verticalInput + _orientationTransform.right * horizontalInput;
        if (inputDirection != Vector3.zero)
        {
            _playerVisualTransform.forward = Vector3.Slerp(_playerVisualTransform.forward, inputDirection.normalized, _rotationSpeed * Time.deltaTime);
        }
    }
        
}
