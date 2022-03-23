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
    [SerializeField] private float _breakJointsDelay = 4f;

    [SerializeField] private Node[] _connectors;
    [SerializeField] private SplineComputer _splineComputer;

    private SplineFollower _follower;
    private Rigidbody[] _vagonsRigidbodies;
    private Rigidbody _rigidbody;
    private float Speed => _follower.followSpeed;
    private void Awake()
    {
        _follower = GetComponent<SplineFollower>();
        _vagonsRigidbodies = GetComponentsInChildren<Rigidbody>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void BecomePhysics()
    {
        _trainEngine.GetComponent<SplineFollower>().enabled = false;
        _splineComputer.enabled = false;
        _rigidbody.isKinematic = false;
        _rigidbody.interpolation = RigidbodyInterpolation.None;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        for (int i = 1; i < _wagons.Length; i++)
        {
            if (_wagons[i].TryGetComponent(out SplinePositioner splinePositioner))
                splinePositioner.enabled = false;

            _vagonsRigidbodies[i].isKinematic = false;
            _vagonsRigidbodies[i].interpolation = RigidbodyInterpolation.None;
            _vagonsRigidbodies[i].collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            _connectors[i].enabled = false;
        }

        StartCoroutine(GoForward(_moveDuration));
        StartCoroutine(BreakJoints(_moveDuration + _breakJointsDelay));
    }

    private IEnumerator GoForward(float actionTime)
    {
        float time = 0;
        Vector3 newVelocity = transform.forward * Speed;

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

    private IEnumerator BreakJoints(float actionTime)
    {
        yield return new WaitForSeconds(actionTime);
        
        for (int i = 1; i < _vagonsRigidbodies.Length; i++)
        {
            if(_vagonsRigidbodies[i].TryGetComponent(out SpringJoint springJoint))
                springJoint.breakForce = 0f;
        }
    }

    public void SetForceDuration(float value)
    {
        _moveDuration = value;
    }
}
