using Cinemachine;
using Dreamteck.Splines;
using System.Collections;
using UnityEngine;

public class AlertZoneSwitch : MonoBehaviour
{
    [SerializeField] private TrainHandleButtons _buttons;
    [SerializeField] private CinemachineVirtualCamera _shoulderCamera;
    [SerializeField] private float _activateButtonsDelay = 1f;
    [SerializeField] private float _deccelerateDuration = 2;
    [SerializeField] private float _slowSpeed = 5f;
    [SerializeField] private float _timeToChose = 5f;

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
            _buttons.Activate(_activateButtonsDelay);
            _trainMovement = trainMovement;
            StartCoroutine(StartCameraZomming());
        }

        Invoke("LostChoise", _timeToChose);
    }

    private void LostChoise()
    {
        _buttons.Deactivate(0);
        _shoulderCamera.gameObject.SetActive(false);
        StartCoroutine(_trainMovement.ChangeSpeed(_slowSpeed, LastSpeed, 0.1f));
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
            _shoulderCamera.m_Lens.FieldOfView = Mathf.Lerp(_shoulderCamera.m_Lens.FieldOfView, 10f, time);
            time += Time.deltaTime / duration;
            yield return null;
        }
    }

}
