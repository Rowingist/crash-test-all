using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TrainMovementButtonsEventHandler : MonoBehaviour
{
    [SerializeField] private Button _accelerate;
    [SerializeField] private Button _deccelerate;
    [SerializeField] private TrainMovement _trainMovement;
    [SerializeField] private SwitchCamerasButtons _switchCamerasButtons;
    [SerializeField] private float _finalButtonsDelay = 5f;
    [SerializeField] private PlayableDirector _thirdCutscene;
    [SerializeField] private BrakesEffectImmiter _brakesEffect;

    private bool IsPaused => ProjectContext.Instance.PauseManager.IsPaused;

    private void OnEnable()
    {
        _accelerate.onClick.AddListener(OnAccelerateProcces);
        _deccelerate.onClick.AddListener(OnDeccelerateProcces);
    }

    private void OnDisable()
    {
        _accelerate.onClick.RemoveListener(OnAccelerateProcces);
        _deccelerate.onClick.RemoveListener(OnDeccelerateProcces);
    }

    private void OnAccelerateProcces()
    {
        if (IsPaused)
            return;

        _trainMovement.Accelerate();
        DeactivateButtons();
        _thirdCutscene.Play();
        Invoke(nameof(ActivateFinalButtons), _finalButtonsDelay);
    }

    private void OnDeccelerateProcces()
    {
        if (IsPaused)
            return;

        _trainMovement.Deccelerate();
        DeactivateButtons();
        _thirdCutscene.Play();
        _brakesEffect.Play();
        Invoke(nameof(ActivateFinalButtons), _finalButtonsDelay);
    }

    private void DeactivateButtons()
    {
        _accelerate.gameObject.SetActive(false);
        _deccelerate.gameObject.SetActive(false);
    }

    private void ActivateFinalButtons()
    {
        _switchCamerasButtons.gameObject.SetActive(true);
    }
}
