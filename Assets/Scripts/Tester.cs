using Dreamteck.Splines;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] private Rigidbody _inspected;
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private AnimationCurve _animationCurveTwo;

    private void Update()
    {
        float x = Time.time;
        float y = _inspected.position.z;
        float z = _inspected.velocity.z;

        Keyframe frame = new Keyframe(x, y, 0, 0, 0, 0);
        Keyframe frameTwo = new Keyframe(x, z, 0, 0, 0, 0);
        _animationCurve.AddKey(frame);
        _animationCurveTwo.AddKey(frameTwo);
    }

}
