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
        transform.SetParent(null);
        _rigidbody.AddForce(_burstDirection.forward * _forcePower);
    }
}
