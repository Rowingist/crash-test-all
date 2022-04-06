using Dreamteck.Splines.Examples;
using MoreMountains.Feedbacks;
using UnityEngine;

public class MainTarget : MonoBehaviour
{
    [SerializeField] private MMFeedbacks _hitFeedbacks;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TrainEngine>())
        {
            _hitFeedbacks.PlayFeedbacks();
            enabled = false;
        }
    }
}
