using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

[RequireComponent(typeof(AppPaused))]
public class GameLogic : MonoBehaviour
{
    [SerializeField] private float _traiStartSpeed;
    [SerializeField] private TrainHandleButtons _playHandleButtons;
    [SerializeField] private SwitchCamerasButtons _switchCamerasButtons;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _accelerate;
    [SerializeField] private Button _deccelerate;
    [SerializeField] private TrainPhysicsSwitch _trainPhysicsSwitch;
    [SerializeField] private TrainMovement _trainMovement;
    [SerializeField] private float _finalButtonsDelay = 4f;

    [SerializeField] private Button _startTutor;
    [SerializeField] private PlayableDirector _firstCutscene;
    [SerializeField] private PlayableDirector _secondCutscene;
    [SerializeField] private PlayableDirector _thirdCutscene;
    [SerializeField] private float _cutscenesTransitionDelay;
    [SerializeField] private BrakesEffectImmiter _brakesEffect;

    [SerializeField] private Menu _sceneTransition;
    [SerializeField] private Button _nextLevel;
    [SerializeField] private Button _nextCamera;
    [SerializeField] private Button _previousCamera;
    [SerializeField] private CutsceneHandle _cutsceneHandle;

    private AppPaused _pause;

    public float TrainStartSpeed => _traiStartSpeed;

    private void Awake()
    {
        _pause = GetComponent<AppPaused>();
    }
    private void OnEnable()
    {
        Invoke(nameof(OnActivateTutor), 2f);
        _pauseButton.onClick.AddListener(OnPauseGame);
        _playButton.onClick.AddListener(OnResumeGame);
        _trainPhysicsSwitch.Enabled += OnActivateFinalButtons;

        _startTutor.onClick.AddListener(OnDepartueTrain);
        _restartButton.onClick.AddListener(Restart);

        _accelerate.onClick.AddListener(OnAccelerateProcces);
        _deccelerate.onClick.AddListener(OnDeccelerateProcces);

        _nextLevel.onClick.AddListener(OnContinue);
        _nextCamera.onClick.AddListener(OnNextCamera);
        _previousCamera.onClick.AddListener(OnPreviousCamera);

        _pause.Paused += OnPauseGame;
        _pause.IsPlaying += OnResumeGame;
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseGame);
        _playButton.onClick.RemoveListener(OnResumeGame);
        _trainPhysicsSwitch.Enabled -= OnActivateFinalButtons;

        _startTutor.onClick.RemoveListener(OnDepartueTrain);
        _restartButton.onClick.RemoveListener(Restart);

        _accelerate.onClick.RemoveListener(OnAccelerateProcces);
        _deccelerate.onClick.RemoveListener(OnDeccelerateProcces);

        _pause.Paused -= OnPauseGame;
        _pause.IsPlaying -= OnResumeGame;
    }

    private void OnActivateHandleButtons()
    {
        Time.timeScale = 0.01f;
        _playHandleButtons.gameObject.SetActive(true);
    }

    private void OnActivateTutor()
    {
        _startTutor.gameObject.SetActive(true);
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


    private void OnActivateFinalButtons()
    {
        Invoke(nameof(ActivateFinalButtons), _finalButtonsDelay);
    }

    private void ActivateFinalButtons()
    {
        _switchCamerasButtons.gameObject.SetActive(true);
    }

    private void OnDepartueTrain()
    {
        Invoke(nameof(ChangeTimeline), _cutscenesTransitionDelay);
        StartCoroutine(_trainMovement.ChangeSpeed(0, TrainStartSpeed, 4f));
        _startTutor.gameObject.SetActive(false);
        _pauseButton.gameObject.SetActive(true);
        _restartButton.gameObject.SetActive(true);
    }

    private void ChangeTimeline()
    {
        _firstCutscene.Stop();
        _secondCutscene.Play();
    }

    private void Restart()
    {
        _sceneTransition.Restart();
    }

    private void OnAccelerateProcces()
    {
        _trainMovement.Accelerate();
        _playHandleButtons.gameObject.SetActive(false);
        _thirdCutscene.Play();
    }

    private void OnDeccelerateProcces()
    {
        _trainMovement.Deccelerate();
        _playHandleButtons.gameObject.SetActive(false);
        _thirdCutscene.Play();
        _brakesEffect.Play();
    }

    private void OnContinue()
    {
        _sceneTransition.GoToNextScene();
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
