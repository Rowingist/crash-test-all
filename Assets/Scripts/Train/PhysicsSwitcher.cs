using UnityEngine;

public class PhysicsSwitcher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out TrainPhysicsSwitch train))
        {
            train.BecomePhysics();
        }
    }
}
