using UnityEngine;

public class PauseTimeScale : MonoBehaviour, IPauseHandler
{
    private void Start()
    {
        ProjectContext.Instance.PauseManager.Register(this);
    }

    public void SetPaused(bool isPaused)
    {
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
