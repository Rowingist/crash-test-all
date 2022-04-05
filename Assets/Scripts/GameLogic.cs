using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private float _traiStartSpeed;
    [SerializeField] private TrainHandleButtons _playHandleButtons;
    [SerializeField] private SwitchCamerasButtons _switchCamerasButtons;
    [SerializeField] private ForkPoint[] _forkPoints;
    [SerializeField] private GameObject _startTutor;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private TrainPhysicsSwitch _trainPhysicsSwitch;
    [SerializeField] private float _finalButtonsDelay = 4f;

    private List<ForkPoint> _forkPointsList = new List<ForkPoint>();
    public float TrainStartSpeed => _traiStartSpeed;

    private void OnEnable()
    {
        Invoke(nameof(OnActivateTutor), 2f);
        for (int i = 0; i < _forkPoints.Length; i++)
        {
            _forkPoints[i].Reached += OnActivateHandleButtons;
            _forkPointsList.Add(_forkPoints[i]);
        }
        _pauseButton.onClick.AddListener(OnPauseGame);
        _playButton.onClick.AddListener(OnResumeGame);
        _trainPhysicsSwitch.Enabled += OnActivateButtons;
    }

    private void OnDisable()
    {
        for (int i = 0; i < _forkPoints.Length; i++)
        {
            _forkPoints[i].Reached += OnActivateHandleButtons;
        }
        _pauseButton.onClick.RemoveListener(OnPauseGame);
        _playButton.onClick.RemoveListener(OnResumeGame);
        _trainPhysicsSwitch.Enabled -= OnActivateButtons;
    }

    private void OnActivateHandleButtons(ForkPoint reachePoint)
    {
        Time.timeScale = 0.01f;
        _playHandleButtons.gameObject.SetActive(true);
        _playHandleButtons.Left.SetButton(reachePoint.LeftButtonImage, reachePoint.LeftSwitcherText);
        _playHandleButtons.Right.SetButton(reachePoint.RightButtonImage, reachePoint.RightSwitcherText);
    }

    private void OnActivateTutor()
    {
        _startTutor.SetActive(true);
    }

    private void OnPauseGame()
    {
        _playButton.gameObject.SetActive(true);
        _pauseButton.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    private void OnResumeGame()
    {
        _playButton.gameObject.SetActive(false);
        _pauseButton.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }


    private void OnActivateButtons()
    {
        Invoke(nameof(ActivateFinalButtons), _finalButtonsDelay);
    }

    private void ActivateFinalButtons()
    {
        _switchCamerasButtons.gameObject.SetActive(true);
    }
}
