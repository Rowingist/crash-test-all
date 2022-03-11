using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarPart : MonoBehaviour
{
    [SerializeField] private float _takeDamageInterval;
    [SerializeField] private SkinnedMeshRenderer _partMeshRenderer;
    [SerializeField] private TMP_Text _healthLable;
    [SerializeField] private int _partNumber;
    [SerializeField] private ParticleSystem _burstEffect;
    [SerializeField] private ParticleSystem _sparcsEffect;
    [SerializeField] private CarMovement _carMovement;
    [SerializeField] private PrometeoCarController _carController;
    [SerializeField, Range(0f, 100f)] private float _deformingSensitivity = 0.5f;
    [SerializeField] private float _deformingDuration = 0.3f;

    private float _damage;
    private float _currentHealth;
    private float _timer;

    private void Start()
    {
        _currentHealth = _partMeshRenderer.GetBlendShapeWeight(_partNumber);
        _healthLable.text = Mathf.RoundToInt(_currentHealth).ToString();
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
                for (int i = 0; i < collision.contacts.Length; i++)
                {
                    _damage += collision.contacts[i].point.magnitude * _deformingSensitivity;
                    ParticleSystem sparcsEffect = Instantiate(_sparcsEffect, collision.contacts[i].point, Quaternion.identity, null);
                    Destroy(sparcsEffect, sparcsEffect.main.duration);
                }

                StartCoroutine(SmoothChangeValue(_deformingDuration, _currentHealth + _damage));
            }
        }
        if (collision.rigidbody.GetComponent<MainTarget>())
        {
            _carMovement.DisableEngine(0);
            _burstEffect.Play();
        }
    }

    private IEnumerator SmoothChangeValue(float actionTime, float newValue)
    {
        float time = 0;
        while (time < 1)
        {
            if(_currentHealth >= 100f)
                yield break;
        
            _currentHealth = Mathf.Lerp(_currentHealth, newValue, time);
            _partMeshRenderer.SetBlendShapeWeight(_partNumber - 1, _currentHealth);
            _healthLable.text = Mathf.RoundToInt(_currentHealth).ToString();
            time += Time.deltaTime / actionTime;
            yield return null;
        }
    }

}
