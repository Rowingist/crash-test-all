using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class TrainMovement : MonoBehaviour
{
    [SerializeField] private float _speedUpStep = 5f;
    [SerializeField] private float _speedDownStep = 5f;
    [SerializeField] private SplineFollower _splineFollower;
    [SerializeField] private float _accelerationDuration;
    [SerializeField] private float _deccelerationDuration;
    [SerializeField] private TrainPhysicsSwitch _trainPhysicsSwitch;

    private float _speedBeforeAlert;
    public void Accelerate()
    {
        float newSpeed = _speedBeforeAlert + _speedUpStep;
        _trainPhysicsSwitch.SetForceDuration(1f);
        StartCoroutine(ChangeSpeed(_speedBeforeAlert, newSpeed, _accelerationDuration));
    }

    public void Deccelerate()
    {
        float newSpeed = _speedBeforeAlert - _speedDownStep;
        _trainPhysicsSwitch.SetForceDuration(0.2f);
        StartCoroutine(ChangeSpeed(_speedBeforeAlert, newSpeed, _deccelerationDuration));
    }

    public IEnumerator ChangeSpeed(float currentSpeed, float newSpeed, float duration)
    {
        float time = 0;
        while (time < 1)
        {
            _splineFollower.followSpeed = Mathf.Lerp(currentSpeed, newSpeed, time * time);
            time += Time.deltaTime / duration;
            yield return null;
        }
    }

    public void SaveCurrentSpeed(float value)
    {
        _speedBeforeAlert = value;
    }
}
