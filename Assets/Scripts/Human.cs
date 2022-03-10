using UnityEditor;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CarMovement _car;
    [SerializeField] private float _rotationSpeed = 200f;
    [SerializeField] private float _detectCarDistance = 5f;
    [SerializeField] private float _runSpeed = 3f;
    [SerializeField] private Animator _animator;

    private int _runAnimationHash;
    private int _prayAnimationHash;

    private void Start()
    {
        _runAnimationHash = Animator.StringToHash("Run");
        _prayAnimationHash = Animator.StringToHash("Pray");
    }

    private void Update()
    {
        float carDistance = Vector3.Distance(transform.position, _car.transform.position);
        if (carDistance < _detectCarDistance)
        {
            _animator.SetTrigger(_runAnimationHash);
            Quaternion runRotation = _car.transform.rotation;
            runRotation.y = -_car.transform.rotation.y;
            transform.rotation = Quaternion.Lerp(transform.localRotation, runRotation, Time.deltaTime * 400f);
            transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, Time.deltaTime * _runSpeed);
        }
        else
        {
            Vector3 targetDirection = _car.transform.position - transform.position;
            Vector3 targetDirectionXZ = new Vector3(targetDirection.x, 0f, targetDirection.z);
            transform.rotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(targetDirectionXZ), Time.deltaTime * _rotationSpeed);
            _rigidbody.velocity = Vector3.zero;
            _animator.SetTrigger(_prayAnimationHash);
        }
    }


#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, Vector3.up, _detectCarDistance);
    }
#endif
}
