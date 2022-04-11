using UnityEngine;

public class MinimizedApplication : MonoBehaviour
{
    private void OnApplicationFocus(bool hasFocus)
    {
        if (ProjectContext.Instance.PauseManager.IsPaused)
            return;

        ProjectContext.Instance.PauseManager.SetPaused(!hasFocus);
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (ProjectContext.Instance.PauseManager.IsPaused)
            return;

        ProjectContext.Instance.PauseManager.SetPaused(pauseStatus);
    }
}
