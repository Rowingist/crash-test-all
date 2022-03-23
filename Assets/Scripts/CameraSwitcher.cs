using Dreamteck.Splines.Examples;
using System.Collections;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _attentionCamera;
    [SerializeField] private GameObject _mainCamera;
    [SerializeField] private float _activeTimeInSeconds;
    [SerializeField] private float _timeScale;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<TrainEngine>())
        {
            _attentionCamera.SetActive(true);
            Time.timeScale = _timeScale;
            StartCoroutine(DelayDeactivation(_activeTimeInSeconds));
        }
    }

    private IEnumerator DelayDeactivation(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        Time.timeScale = 1f;
        _attentionCamera.SetActive(false);
        _mainCamera.SetActive(true);
        Destroy(gameObject);
    }
}
