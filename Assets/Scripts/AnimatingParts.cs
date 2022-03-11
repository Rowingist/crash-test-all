using System.Collections;
using UnityEngine;

public class AnimatingParts : MonoBehaviour
{
    [SerializeField] private GameObject _wheelBL;
    [SerializeField] private GameObject _wheelBR;
    [SerializeField] private GameObject _wheelFL;
    [SerializeField] private GameObject _wheelFR;
    [SerializeField] private GameObject _body;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _refreshDelay = 0.1f;

    private void Awake()
    {
        _wheelBL.name = "Wheel_BL";
        _wheelBR.name = "Wheel_BR";
        _wheelFL.name = "Wheel_FL";
        _wheelFR.name = "Wheel_FR";
        _body.name = "rustcar_510_RED";
    }
}
