using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class CarMovementHandler : MonoBehaviour
{
    [SerializeField] private Joystick _horizontalMoveJoystick;
    [SerializeField] private Joystick _verticalMoveJoystick;
    [SerializeField] private PrometeoCarController _carController;
    [SerializeField] private float _moveSensitinity = 2f;
    [SerializeField] private float _backToLineSpeed = 5f;
    [SerializeField] private float _turnOffEngineDelay = 3f;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _firstAccelerationSeed = 40f;
    [SerializeField] private CinemachineVirtualCamera _shakingVirtualCamera;
    [SerializeField] private Button _startButton;
    [SerializeField] private WheelCollider _rearRightWheelCollider;

    private Quaternion _startRotation;
    private Rigidbody _rigidbody;
    private float _lastInputY;
    private float _inputTorque;

    private CarStates _currentCarState;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartAcceleration);
    }
    private void Start()
    {
        _startRotation = transform.rotation;
        _currentCarState = CarStates.BurnOut;
        _lastInputY = 0f;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _carController.Turn(_horizontalMoveJoystick.Delta.x * _moveSensitinity);

        if (_rearRightWheelCollider.motorTorque != 0f)
        {
            _inputTorque = (_rearRightWheelCollider.motorTorque / 10f + _verticalMoveJoystick.Delta.y * _moveSensitinity);
        }
        else
        {
            _inputTorque = _verticalMoveJoystick.Delta.y * _moveSensitinity;
        }

        if (_currentCarState == CarStates.BurnOut)
        {

            _carController.BurnOutRearDrive(_inputTorque);
        }
        else if (_currentCarState == CarStates.Accelerate)
        {
            _carController.MoveForward(_inputTorque);
        }


        if (_currentCarState == CarStates.Brakes)
        {
            _carController.BrakeAllWheels();
        }

    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartAcceleration);
    }

    private void OnStartAcceleration()
    {
        _currentCarState = CarStates.Accelerate;
        _animator.SetTrigger("Accelerate");
        _startButton.gameObject.SetActive(false);
    }

}
