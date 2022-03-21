using UnityEngine;

public class TrainHandleButtons : MonoBehaviour
{
    [SerializeField] private TrackHandleButton _left;
    [SerializeField] private TrackHandleButton _right;

    public TrackHandleButton Left => _left;
    public TrackHandleButton Right => _right;

    private void Start()
    {
        gameObject.SetActive(false);
    }
}
