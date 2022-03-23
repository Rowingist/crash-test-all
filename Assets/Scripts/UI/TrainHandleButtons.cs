using UnityEngine;
using UnityEngine.UI;

public class TrainHandleButtons : MonoBehaviour
{
    [SerializeField] private TrackHandleButton _left;
    [SerializeField] private TrackHandleButton _right;

    public TrackHandleButton Left => _left;
    public TrackHandleButton Right => _right;

    public void Activate(float delay)
    {
        Invoke("SetOnState", delay);
    }

    public void Deactivate(float delay)
    {
        Invoke("SetOffState", delay);
    }

    private void SetOnState()
    {
        _left.gameObject.SetActive(true);
        _right.gameObject.SetActive(true);
    }

    private void SetOffState()
    {
        _left.gameObject.SetActive(false);
        _right.gameObject.SetActive(false);
    }
}
