using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tachometer : MonoBehaviour
{
    [SerializeField] private WheelCollider _reareRightWheelCollider;
    [SerializeField] private TextMeshProUGUI _tachometerText;
    [SerializeField] private Slider _tachometerSlider;
    [SerializeField] private float _updateFrequency = 1f;

    private float _currentTorque;
    private float _oldTorque;
    private float _maxTorque;

    private void Start()
    {
        _maxTorque = 2000f;
        _tachometerSlider.value = _currentTorque / _maxTorque;
    }
    private void Update()
    {
        SetValueSmooth();
    }
    private void SetValueSmooth()
    {
        _currentTorque = Mathf.Lerp(_oldTorque, _reareRightWheelCollider.motorTorque, Time.deltaTime * _updateFrequency);
        _tachometerText.SetText("torgue\n " + Mathf.RoundToInt(_currentTorque * 0.1f).ToString() + " x10");
        _tachometerSlider.value = _currentTorque / _maxTorque;
        _oldTorque = _currentTorque;
    }
}
