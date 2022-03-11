using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarPart : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private Rigidbody _carRigidBody;
    //[SerializeField] private SkinnedMeshRenderer _partMeshRenderer;
    [SerializeField] private TMP_Text _healthLable;
    [SerializeField] private int _partNumber;
    [SerializeField] private ParticleSystem _burstEffect;
    [SerializeField] private ParticleSystem _sparcsEffect;

    private float _damage;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthLable.text = Mathf.RoundToInt(_currentHealth).ToString();
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {

        if (collision.rigidbody.GetComponent<Obstacle>())
        {
            for (int i = 0; i < collision.contacts.Length; i++)
            {
                _damage += collision.contacts[i].point.magnitude;
                ParticleSystem sparcsEffect = Instantiate(_sparcsEffect, collision.contacts[i].point, Quaternion.identity, null);
                Destroy(sparcsEffect, sparcsEffect.main.duration);
            }

            StartCoroutine(SmoothChangeValue(3f, _currentHealth - _damage));
        }
        if (collision.rigidbody.GetComponent<MainTarget>())
        {
            _burstEffect.Play();
        }
    }

    private IEnumerator SmoothChangeValue(float actionTime, float newValue)
    {
        float time = 0;
        while (time < 1)
        {
            if(_currentHealth <= 0f)
                yield break;
        
            _currentHealth = Mathf.Lerp(_currentHealth, newValue, time);
            _healthLable.text = Mathf.RoundToInt(_currentHealth).ToString();
            time += Time.deltaTime / actionTime;
            yield return null;
        }
    }

}
