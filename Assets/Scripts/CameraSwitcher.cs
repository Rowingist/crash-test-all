using System.Collections;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _firstTurnOffCamera;
    [SerializeField] private GameObject _secondTurnOffCamera;
    [SerializeField] private float _activeTimeInSeconds;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CarMovement>())
        {
            _firstTurnOffCamera.SetActive(false);
            Time.timeScale = 0.1f;
            StartCoroutine(DelayDeactivation(_activeTimeInSeconds));
        }
    }

    private IEnumerator DelayDeactivation(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        _secondTurnOffCamera.SetActive(false);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
