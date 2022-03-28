using MoreMountains.Feedbacks;
using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private MMFeedbacks _hitFeedbacks;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.GetComponent<Obstacle>())
        {
            _hitFeedbacks.PlayFeedbacks();
            enabled = false;
        }
    }
}
