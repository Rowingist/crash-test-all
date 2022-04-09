using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppPaused : MonoBehaviour
{
    public event Action Paused;
    public event Action IsPlaying;

    private bool _isPaused;
    private void Start()
    {
        _isPaused = false;
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        _isPaused = !hasFocus;
        if (hasFocus)
        {
            IsPlaying?.Invoke();
        }
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        _isPaused = pauseStatus;
        Paused?.Invoke();
    }
}
