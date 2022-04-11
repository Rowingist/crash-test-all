using UnityEngine;
using UnityEngine.UI;

public class UpperButtonsEventHandler : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private GameSequence _gameScenesSequence;

    private bool IsPaused => ProjectContext.Instance.PauseManager.IsPaused;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnPauseGame);
        _playButton.onClick.AddListener(OnResumeGame);
        _restartButton.onClick.AddListener(Restart);
    }

    private void Update()
    {
        if (IsPaused)
        {
            _playButton.gameObject.SetActive(true);
            _pauseButton.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseGame);
        _playButton.onClick.RemoveListener(OnResumeGame);
        _restartButton.onClick.RemoveListener(Restart);
    }

    private void OnPauseGame()
    {
        ProjectContext.Instance.PauseManager.SetPaused(true);
        _playButton.gameObject.SetActive(true);
        _pauseButton.gameObject.SetActive(false);
    }

    private void OnResumeGame()
    {
        ProjectContext.Instance.PauseManager.SetPaused(false);
        _playButton.gameObject.SetActive(false);
        _pauseButton.gameObject.SetActive(true);
    }

    private void Restart()
    {
        if (IsPaused)
            return;

        _gameScenesSequence.Restart();
    }

    public void ActivateButtons()
    {
        _restartButton.gameObject.SetActive(true);
        _pauseButton.gameObject.SetActive(true);
    }
}
