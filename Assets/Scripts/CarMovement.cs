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
    [SerializeField] private float _turnOffEngineDelay = 3f;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _firstAccelerationSeed = 40f;
    [SerializeField] private CinemachineVirtualCamera _shakingVirtualCamera;

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
        _carController.Turn(_moveJoystick.Delta.x * _moveSensitinity);
        _carController.AnimateReareWheelMeshes();
    }
    private void FixedUpdate()
    {
        _rigidbody.rotation = Quaternion.Lerp(_rigidbody.rotation, _startRotation, _backToLineSpeed * Time.deltaTime);
        if (Input.touches.Length == 0)
        {
            return;
        }
        _animator.SetTrigger("Accelerate");
        StartCoroutine(AccelerateCar(3f, _carController));
        _rigidbody.AddForce(transform.forward * _firstAccelerationSeed, ForceMode.Acceleration);
        _shakingVirtualCamera.gameObject.SetActive(false);
    }

    private IEnumerator AccelerateCar(float actionTime, PrometeoCarController carController)
    {
        float time = 0;
        while (time < 1)
        {
            carController.GoForward();
            carController.AnimateWheelMeshes();
            carController.RLWTireSkid.emitting = true;
            carController.RRWTireSkid.emitting = true;
            carController.isDrifting = true;
            time += Time.deltaTime / actionTime;
            yield return null;
        }
        carController.RLWTireSkid.emitting = false;
        carController.RRWTireSkid.emitting = false;
        carController.isDrifting = false;
        StartCoroutine(DisableEngine(_turnOffEngineDelay));
    }

    private IEnumerator DisableEngine(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        _carController.ThrottleOff();
        _carController.ReleaseBrakes();
        enabled = false;
    }

}
