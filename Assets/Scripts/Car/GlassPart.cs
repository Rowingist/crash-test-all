using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GlassPart : MonoBehaviour
{
    [SerializeField] private float _forcePower;
    [SerializeField] private float _animationTime;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Crash()
    {
        transform.SetParent(null);
        StartCoroutine(Fly(_animationTime));
    }

    private IEnumerator Fly(float actionTime)
    {
        float time = 0;
        while (time < 1)
        {
            _rigidbody.AddForce(transform.forward * _forcePower, ForceMode.VelocityChange);
            time += Time.deltaTime / actionTime;
            yield return null;
        }
    }
}
