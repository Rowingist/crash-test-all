using UnityEngine;
using UnityEngine.UI;

public class FinalButtonsEventHandler : MonoBehaviour
{
    [SerializeField] private GameSequence _gameSceneSequence;
    [SerializeField] private Button _nextLevel;
    [SerializeField] private Button _nextCamera;
    [SerializeField] private Button _previousCamera;
    [SerializeField] private CutsceneHandle _cutsceneHandle;

    private bool IsPaused => ProjectContext.Instance.PauseManager.IsPaused;

    private void OnEnable()
    {
        _nextLevel.onClick.AddListener(OnContinue);
        _nextCamera.onClick.AddListener(OnNextCamera);
        _previousCamera.onClick.AddListener(OnPreviousCamera);
    }

    private void OnDisable()
    {
        _nextLevel.onClick.RemoveListener(OnContinue);
        _nextCamera.onClick.RemoveListener(OnNextCamera);
        _previousCamera.onClick.RemoveListener(OnPreviousCamera);
    }

    private void OnContinue()
    {
        if (IsPaused)
            return;

        _gameSceneSequence.NextScene();
    }

    private void OnNextCamera()
    {
        _cutsceneHandle.EnableNextCamera();
    }

    private void OnPreviousCamera()
    {
        _cutsceneHandle.EnablePreviousCamera();
    }
}
