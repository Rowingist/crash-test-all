using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _speedometerText;
    [SerializeField] private Rigidbody _carRigidbody;
    [SerializeField] private float _frequency = 1f;

    private float _currentSpeed;
    private float _oldSpeed;
    private const float _kmToMiles = 2.2369362920544f;


    private void Update()
    {
        _currentSpeed = Mathf.Lerp(_oldSpeed, _carRigidbody.velocity.z * _kmToMiles, Time.deltaTime * _frequency);
        _speedometerText.SetText(Mathf.RoundToInt(_currentSpeed).ToString() + " mph");
        _oldSpeed = _currentSpeed;
    }

}
