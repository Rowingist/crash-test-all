using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class WagonPhysicsSwitch : MonoBehaviour
{
    [SerializeField] private SplineFollower _splineFollower;
    [SerializeField] private Rigidbody _ahead;

    private void Update()
    {
        if (_splineFollower.enabled == false)
        {
            HingeJoint joint = gameObject.AddComponent<HingeJoint>();
            joint.connectedBody = _ahead;
            JointLimits newLimits = new JointLimits();
            newLimits.min = -16f;
            newLimits.max = 62f;
            joint.limits = newLimits;
            joint.anchor = new Vector3(0f, 0.61f, 3.3f);

            GetComponent<SplinePositioner>().enabled = false;
            enabled = false;
        }
    }
}
