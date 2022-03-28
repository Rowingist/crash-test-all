using UnityEngine.Playables;
using UnityEngine;

public class CutsceneHandle : MonoBehaviour
{
    [SerializeField] private PlayableDirector _handledTimeline;
    [SerializeField] private float[] _cameraSwitchTimePoints;
    [SerializeField] private float _timeLineDuration;

    private double _currentCameraTime => _handledTimeline.time;

    public void EnableNextCamera()
    {
        for (int i = 0; i < _cameraSwitchTimePoints.Length; i++)
        {
            if(_cameraSwitchTimePoints[i] / 60 > _currentCameraTime)
            {
                _handledTimeline.time = _cameraSwitchTimePoints[i] / 60;
                return;
            }
        }
        _handledTimeline.time = 0f;
    }

    public void EnablePreviousCamera()
    {
        for (int i = _cameraSwitchTimePoints.Length - 1; i > 0; i--)
        {
            if (_cameraSwitchTimePoints[i] / 60 < _currentCameraTime)
            {
                _handledTimeline.time = _cameraSwitchTimePoints[i - 1] / 60;
                return;
            }
        }
        _handledTimeline.time = _cameraSwitchTimePoints[_cameraSwitchTimePoints.Length - 1] / 60;
    }

}
