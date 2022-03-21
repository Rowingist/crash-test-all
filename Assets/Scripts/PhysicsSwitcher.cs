using Cinemachine;
using Dreamteck.Splines.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _fallZoneCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out TrainPhysicsSwitch train))
        {
            _fallZoneCamera.gameObject.SetActive(true);
            train.BecomePhysics();
        }
    }
}
