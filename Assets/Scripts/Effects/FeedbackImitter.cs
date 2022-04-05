using MoreMountains.Feedbacks;
using UnityEngine;

public class FeedbackImitter : MonoBehaviour
{
    [SerializeField] private MMFeedbacks _camerashakes;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("spase");
            _camerashakes?.PlayFeedbacks();
        }
    }
}
