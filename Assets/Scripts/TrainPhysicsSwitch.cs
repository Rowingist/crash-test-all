using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using Dreamteck.Splines.Examples;

public class TrainPhysicsSwitch : MonoBehaviour
{
    [SerializeField] private TrainEngine _trainEngine;
    [SerializeField] private Wagon[] _wagons;

    [SerializeField] private float _moveDuration;
    [SerializeField] private float _moveForce;

    [SerializeField] private Node[] _connectors;
    [SerializeField] private SplineComputer _splineComputer;

    private Rigidbody[] _vagonsRigidbodies;
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _vagonsRigidbodies = GetComponentsInChildren<Rigidbody>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void BecomePhysics()
    {
        _trainEngine.GetComponent<SplineFollower>().enabled = false;
        _splineComputer.enabled = false;
        for (int i = 0; i < _wagons.Length; i++)
        {
            if (_wagons[i].TryGetComponent(out SplinePositioner splinePositioner))
                splinePositioner.enabled = false;

            _wagons[i].GetComponent<Rigidbody>().isKinematic = false;
            _connectors[i].enabled = false;
        }

        StartCoroutine(GoForward(_moveDuration));
    }

    private IEnumerator GoForward(float actionTime)
    {
        GetComponent<Wagon>().isEngine = false;
        float time = 0;
        Vector3 newVelocity = transform.forward + new Vector3(0, 0, _moveForce);
        while (time < 1f)
        {
            _rigidbody.velocity = newVelocity;
            for (int i = 0; i < _vagonsRigidbodies.Length; i++)
            {
                _vagonsRigidbodies[i].velocity = newVelocity;
            }
            time += Time.deltaTime / actionTime;
            yield return null;
        }
    }
}
