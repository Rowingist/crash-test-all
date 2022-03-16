using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GlassPart : MonoBehaviour
{
    [SerializeField] private Transform _burstDirection;
    [SerializeField] private float _forcePower;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Crash()
    {
        Vector3 randomDirection = new Vector3(Random.Range(-2f, 2f), Random.Range(1f, 4f), Random.Range(-5f, 5f));
        _rigidbody.AddForce(_burstDirection.forward + randomDirection * _forcePower, ForceMode.VelocityChange);
    }
}
