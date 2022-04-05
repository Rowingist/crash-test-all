using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointsGlue : MonoBehaviour
{
    [SerializeField] private InteractionProcessor[] _interactionProcessors;
    [SerializeField] private float _hitBakeDelay = 1f;

    private Vector3 _startLocalPosition;
    private Quaternion _startLocalRotation;

    private void OnEnable()
    {
        for (int i = 0; i < _interactionProcessors.Length; i++)
        {
            _interactionProcessors[i].Crashed += OnEnableJoints;
        }
    }

    private void Start()
    {
        _startLocalPosition = transform.localPosition;
        _startLocalRotation = transform.localRotation;
    }

    private void Update()
    {
        transform.localPosition = _startLocalPosition;
        transform.localRotation = _startLocalRotation;
    }

    private void OnDisable()
    {
        for (int i = 0; i < _interactionProcessors.Length; i++)
        {
            _interactionProcessors[i].Crashed -= OnEnableJoints;
        }
    }

    private void OnEnableJoints()
    {
        Destroy(this, _hitBakeDelay);
    }
}
