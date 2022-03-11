using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private WheelCollider _leftBackWheel;
    [SerializeField] private WheelCollider _rightBackWheel;
    [SerializeField] private WheelCollider _leftFrontWheel;
    [SerializeField] private WheelCollider _rightFrontWheel;
    [SerializeField] private float _maxMotorTorque = 10f;
    [SerializeField] private float _maxSteerAngne = 30f;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Vector3 _centerOfMass;
    [SerializeField] private float _brakeForce = 1000f;

    private void FixedUpdate()
    {
        _leftBackWheel.motorTorque = Input.GetAxis("Vertical") * _maxMotorTorque;
        _rightBackWheel.motorTorque = Input.GetAxis("Vertical") * _maxMotorTorque;
        BrakeFrontAxis();

        _leftFrontWheel.steerAngle = Input.GetAxis("Horizontal") * _maxSteerAngne;
        _rightFrontWheel.steerAngle = Input.GetAxis("Horizontal") * _maxSteerAngne;
    }

    public void BrakeFrontAxis()
    {
        _rightFrontWheel.brakeTorque = _brakeForce;
        _leftFrontWheel.brakeTorque = _brakeForce;
    }
}
