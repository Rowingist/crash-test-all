using UnityEngine;

public class WheelModel : MonoBehaviour
{
    [SerializeField] private WheelCollider _wheelCollider;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        Vector3 position;
        Quaternion rotation;

        _wheelCollider.GetWorldPose(out position, out rotation);
        _transform.position = position;
        _transform.rotation = rotation;
    }
}
