using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GlassPart : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Crash(float force, float duration)
    {
        transform.SetParent(null);
        StartCoroutine(Fly(force, duration));
    }

    private IEnumerator Fly(float force, float actionTime)
    {
        float time = 0;
        while (time < 1)
        {
            _rigidbody.AddForce(transform.forward * force, ForceMode.VelocityChange);
            time += Time.deltaTime / actionTime;
            yield return null;
        }
    }
}
