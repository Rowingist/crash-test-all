using System;
using System.Collections;
using UnityEngine;

public class PartDeformation : MonoBehaviour
{
    [SerializeField] private float _takeDamageInterval;
    [SerializeField] private SkinnedMeshRenderer _partMeshRenderer;
    [SerializeField] private int _partNumber;
    [SerializeField] private ParticleSystem _sparcsEffect;
    [SerializeField, Range(0f, 100f)] private float _deformingSensitivity = 0.5f;
    [SerializeField] private float _deformingDuration = 0.3f;

    private float _damage;
    private float _currentHealth;
    private float _timer;

    public event Action<UnityEngine.Collision> Hit;
    private void Start()
    {
        _currentHealth = _partMeshRenderer.GetBlendShapeWeight(_partNumber);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (_timer >= _takeDamageInterval)
        {
            _timer = 0f;
            if (collision.rigidbody.GetComponent<Obstacle>())
            {
                int randomPoint = UnityEngine.Random.Range(0, collision.contacts.Length);
                _damage += collision.contacts[randomPoint].point.magnitude * _deformingSensitivity;
                ParticleSystem sparcsEffect = Instantiate(_sparcsEffect, collision.contacts[randomPoint].point, Quaternion.identity, null);
                Destroy(sparcsEffect, sparcsEffect.main.duration);
                StartCoroutine(SmoothChangeValue(_deformingDuration, _currentHealth + _damage));
                Hit?.Invoke(collision);
            }
        }
    }

    private IEnumerator SmoothChangeValue(float actionTime, float newValue)
    {
        float time = 0;
        while (time < 1)
        {
            if (_currentHealth >= 100f)
                yield break;

            _currentHealth = Mathf.Lerp(_currentHealth, newValue, time);
            _partMeshRenderer.SetBlendShapeWeight(_partNumber - 1, _currentHealth);
            time += Time.deltaTime / actionTime;
            yield return null;
        }
    }
}
