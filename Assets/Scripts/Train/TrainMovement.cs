using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class TrainMovement : MonoBehaviour
{
    [SerializeField] private float _upSpeed = 5f;
    [SerializeField] private float _downSpeed = 5f;
    [SerializeField] private SplineFollower _splineFollower;
    [SerializeField] private float _accelerationDuration;
    [SerializeField] private float _deccelerationDuration;
    [SerializeField] private TrainPhysicsSwitch _trainPhysicsSwitch;

    private float _speedBeforeAlert;
    public void Accelerate()
    {
        _trainPhysicsSwitch.SetForceDuration(1f);
        StartCoroutine(ChangeSpeed(_speedBeforeAlert, _upSpeed, _accelerationDuration));
    }

    public void Deccelerate()
    {
        _trainPhysicsSwitch.SetForceDuration(0.2f);
        StartCoroutine(ChangeSpeed(_speedBeforeAlert, _downSpeed, _deccelerationDuration));
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

        if(newSpeed == 0)
        {
            _splineFollower.enabled = false;
        }
    }

    public void SaveCurrentSpeed(float value)
    {
        _speedBeforeAlert = value;
    }
}
