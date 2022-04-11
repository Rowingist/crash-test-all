using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InteractionProcessor))]
public class DamageablePart : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _partRenderer;
    [SerializeField] private int _numberInMeshRenderer;
    [SerializeField] private float _timeIntervalInSeconds = 1f;
    [SerializeField] private float _deformingDuration = 0.3f;
    [SerializeField] private EffectsGenerator _effectsGenerator;
    [SerializeField] private bool _isSavingLocalPosition;

    private InteractionProcessor _interactionProcessor;
    private float _currentHealth;
    private float _elapsedTime;
    private Vector3 _startLocalPosition;
    private Quaternion _startLocalRotation;

    private float _deformingSensitivity = 2f;
    private const float ANDROID_TIME_ENCREASER = 3f;
    private void OnValidate()
    {
        _deformingDuration = Mathf.Clamp(_deformingDuration, 0f, _timeIntervalInSeconds);
    }

    private void Awake()
    {
        _interactionProcessor = GetComponent<InteractionProcessor>();
    }

    private void OnEnable()
    {
        _interactionProcessor.Affected += OnDeform;
    }

    private void Start()
    {
        _currentHealth = _partRenderer.GetBlendShapeWeight(_numberInMeshRenderer - 1);
        _startLocalPosition = transform.localPosition;
        _startLocalRotation = transform.localRotation;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_isSavingLocalPosition)
        {
            transform.localPosition = _startLocalPosition;
            transform.localRotation = _startLocalRotation;
        }
    }

    private void OnDisable()
    {
        _interactionProcessor.Affected += OnDeform;
    }

    private void OnDeform(Vector3 interactionPoint, float damage)
    {
        if (_elapsedTime >= _timeIntervalInSeconds)
        {
            _elapsedTime = 0f;
            _effectsGenerator.Play(interactionPoint);
            SmoothTakeDamage(damage);
        }
    }

    public void SmoothTakeDamage(float damage)
    {
        _partRenderer.SetBlendShapeWeight(_numberInMeshRenderer - 1, _currentHealth + damage * _deformingSensitivity);
    }

    private IEnumerator SmoothChangeValue(float actionTime, float damage)
    {
        float time = 0;
        float damaged = _currentHealth + damage * _deformingSensitivity;
        while (_currentHealth <= damaged)
        {
            if (_currentHealth >= 100f)
                yield break;

            _currentHealth = Mathf.Lerp(_currentHealth, _currentHealth + damage * _deformingSensitivity, time);
            _partRenderer.SetBlendShapeWeight(_numberInMeshRenderer - 1, _currentHealth);
            time += Time.deltaTime * ANDROID_TIME_ENCREASER / actionTime;
            yield return null;
        }
    }
}
