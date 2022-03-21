using Dreamteck.Splines;
using Dreamteck.Splines.Examples;
using System;
using UnityEngine;

public class ForkPoint : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private bool _isPointWithTutor;
    [SerializeField] private ForkTutor _forkTutorUI;
    [TextArea(1, 5)] [SerializeField] private string _leftSwitcherText;
    [TextArea(1, 5)] [SerializeField] private string _rightSwitcherText;
    [SerializeField] private SplineComputer _leftButtonLine;
    [SerializeField] private SplineComputer _rightButtonLine;

    public int Index => _index;
    public string LeftSwitcherText => _leftSwitcherText;
    public string RightSwitcherText => _rightSwitcherText;
    public SplineComputer LeftButtonLine => _leftButtonLine;
    public SplineComputer RightButtonLine => _rightButtonLine;

    public event Action<ForkPoint> Reached;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TrainEngine>())
        {
            if (_isPointWithTutor)
            {
                _forkTutorUI.gameObject.SetActive(true);
            }

            Reached?.Invoke(this);
        }
    }
}
