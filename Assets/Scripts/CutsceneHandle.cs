using UnityEngine.Playables;
using UnityEngine;

public class CutsceneHandle : MonoBehaviour
{
    [SerializeField] private PlayableDirector _handledTimeline;
    [SerializeField] private float[] _cameraSwitchTimePoints;

    private double _currentCameraTime => _handledTimeline.time;
    private const int ONE_MINUTE_IN_SECONDS = 60;

    public void EnableNextCamera()
    {
        for (int i = 0; i < _cameraSwitchTimePoints.Length; i++)
        {
            float instantTimePoint = _cameraSwitchTimePoints[i] / ONE_MINUTE_IN_SECONDS;
            if (instantTimePoint > _currentCameraTime)
            {
                _handledTimeline.time = instantTimePoint;
                return;
            }
        }
        _handledTimeline.time = 0f;
    }

    public void EnablePreviousCamera()
    {
        for (int i = _cameraSwitchTimePoints.Length - 1; i > 0; i--)
        {
            if (_cameraSwitchTimePoints[i] / ONE_MINUTE_IN_SECONDS < _currentCameraTime)
            {
                _handledTimeline.time = _cameraSwitchTimePoints[i - 1] / ONE_MINUTE_IN_SECONDS;
                return;
            }
        }
        _handledTimeline.time = _cameraSwitchTimePoints[_cameraSwitchTimePoints.Length - 1] / ONE_MINUTE_IN_SECONDS;
    }
}
