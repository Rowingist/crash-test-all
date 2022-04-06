using Cinemachine;
using Dreamteck.Splines;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class AlertZoneSwitch : MonoBehaviour
{
    [SerializeField] private TrainHandleButtons _buttons;
    [SerializeField] private CinemachineVirtualCamera _shoulderCamera;
    [SerializeField] private PlayableDirector _directorToSwitchOff;
    [SerializeField] private float _deccelerateDuration = 2;
    [SerializeField] private float _slowSpeed = 5f;
    [SerializeField] private float _timeToChose = 5f;
    [SerializeField] private PlayableDirector _thirdCutScene;

    private TrainMovement _trainMovement;
    public float LastSpeed { get; private set; }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out TrainMovement trainMovement))
        {
            LastSpeed = trainMovement.GetComponent<SplineFollower>().followSpeed;
            trainMovement.SaveCurrentSpeed(LastSpeed);
            StartCoroutine(trainMovement.ChangeSpeed(LastSpeed, _slowSpeed, _deccelerateDuration));
            _shoulderCamera.gameObject.SetActive(true);
            Invoke(nameof(ActivateHandleButtons), 0.5f);
            _trainMovement = trainMovement;
            StartCoroutine(StartCameraZomming());
        }

        Invoke(nameof(LostChoise), _timeToChose);
    }

    private void LostChoise()
    {
        _buttons.gameObject.SetActive(false);
        _shoulderCamera.gameObject.SetActive(false);
        if (_trainMovement)
        {
            StartCoroutine(_trainMovement.ChangeSpeed(_slowSpeed, LastSpeed, 0.1f));
            _thirdCutScene.Play();
        }
    }

    private IEnumerator StartCameraZomming()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(ZoomAlert(200f));
    }

    private IEnumerator ZoomAlert(float duration)
    {
        float time = 0;
        while (time < 1)
        {
            _shoulderCamera.m_Lens.FieldOfView = Mathf.Lerp(_shoulderCamera.m_Lens.FieldOfView, 40f, time);
            time += Time.deltaTime / duration;
            yield return null;
        }
    }

    private void ActivateHandleButtons()
    {
        _buttons.gameObject.SetActive(true);
    }

}
