using Cinemachine;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarMovement : MonoBehaviour
{
    [SerializeField] private Joystick _moveJoystick;
    [SerializeField] private PrometeoCarController _carController;
    [SerializeField] private float _moveSensitinity = 2f;
    [SerializeField] private float _backToLineSpeed = 5f;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _firstAccelerationSeed = 40f;
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

    private Quaternion _startRotation;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _startRotation = transform.rotation;
        _carController.RLWParticleSystem.Play();
        _carController.RRWParticleSystem.Play();
    }

    private void Update()
    {
        if (Input.touches.Length > 0)
        {
            _animator.SetTrigger("Accelerate");
            StartCoroutine(AccelerateCar(0.5f, _carController));
            _rigidbody.AddForce(transform.forward * _firstAccelerationSeed, ForceMode.Acceleration);
            _cinemachineVirtualCamera.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.rotation =  Quaternion.Lerp(_rigidbody.rotation, _startRotation, _backToLineSpeed * Time.deltaTime);
    }

    private IEnumerator AccelerateCar(float actionTime, PrometeoCarController carController)
    {
        float time = 0;
        while (time < 1)
        {
            _carController.Turn(_moveJoystick.Delta.x * _moveSensitinity);
            carController.GoForward();
            carController.RLWTireSkid.emitting = true;
            carController.RRWTireSkid.emitting = true;
            carController.isDrifting = true;
            time += Time.deltaTime / actionTime;
            yield return null;
        }
        carController.RLWTireSkid.emitting = false;
        carController.RRWTireSkid.emitting = false;
        carController.isDrifting = false;
        enabled = false;
    }

}
