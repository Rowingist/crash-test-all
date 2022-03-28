using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Obstacle
{
    [SerializeField] private DustEffectsTrigger _dustTrigger;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponentInChildren<Obstacle>())
            {
                _dustTrigger.PlayEffect();
                enabled = false;
            }
        }
    }
}
