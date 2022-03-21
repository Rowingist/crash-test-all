using System;
using System.Collections;
using UnityEngine;

public class Deformation : MonoBehaviour
{
    [SerializeField] private float _timeIntervalInSeconds = 1f;
    [SerializeField] private float _deformingDuration = 0.3f;
    [SerializeField] private VehiclePart[] _affectedParts;
    [SerializeField] private ParticleSystem _sparcsEffect;

    private float _force;

    private float _timer;

    public event Action<Collision> Hit;

    private void Update()
    {
        _timer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_timer >= _timeIntervalInSeconds)
        {
            _timer = 0f;
            if (collision.rigidbody.GetComponent<Obstacle>())
            {
                for (int i = 0; i < collision.contactCount; i++)
                {
                    _force += collision.contacts[i].point.magnitude;
                    PlayEffect(collision.contacts[i].point);
                    Hit?.Invoke(collision);
                }

                for (int i = 0; i < _affectedParts.Length; i++)
                {
                    _affectedParts[i].TakeDamage(_deformingDuration, _force);
                }
            }
        }
    }

    private void PlayEffect(Vector3 position)
    {
        ParticleSystem sparcsEffect = Instantiate(_sparcsEffect, position, Quaternion.identity, null);
        Destroy(sparcsEffect, 0.5f);
    }


}
