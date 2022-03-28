using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiclePart : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float _deformingSensitivity = 0.5f;
    [SerializeField] private bool _isSavingPosition;
    [SerializeField] private SkinnedMeshRenderer _partRenderer;
    [SerializeField] private int _numberInMeshRenderer;

    private float _currentHealth;
    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private void Start()
    {
        _currentHealth = _partRenderer.GetBlendShapeWeight(_numberInMeshRenderer - 1);
        _startPosition = transform.localPosition;
        _startRotation = transform.localRotation;
    }

    private void Update()
    {
        if (_isSavingPosition)
        {
            transform.localPosition = _startPosition;
            transform.localRotation = _startRotation;
        }
    }

    public void TakeDamage(float actionTime, float damage)
    {
        StartCoroutine(SmoothChangeValue(actionTime, damage));
    }

    private IEnumerator SmoothChangeValue(float actionTime, float newValue)
    {
        float time = 0;
        while (time < 1)
        {
            if (_currentHealth >= 100f)
                yield break;

            _currentHealth = Mathf.Lerp(_currentHealth, _deformingSensitivity * newValue, time);
            _partRenderer.SetBlendShapeWeight(_numberInMeshRenderer - 1, _currentHealth);
            time += Time.deltaTime / actionTime;
            yield return null;
        }
    }
}
