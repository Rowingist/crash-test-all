using Dreamteck.Splines;
using System;
using UnityEngine;

public class InteractionProcessor : MonoBehaviour
{
    private float _converterToRigidBodyVelocity = 20f;

    public event Action<Vector3, float> Affected;
    public event Action Crashed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<DamageEffector>())
            {
                float force = collision.relativeVelocity.magnitude;
                Vector3 firstTouchPoint = collision.GetContact(0).point;

                if (collision.rigidbody.TryGetComponent(out SplineFollower train))
                {
                    Affected?.Invoke(firstTouchPoint, train.followSpeed / _converterToRigidBodyVelocity);
                    Crashed?.Invoke();
                }
                else if (force > 0f)
                {
                    Affected?.Invoke(firstTouchPoint, force);
                }
            }
        }
    }
}
