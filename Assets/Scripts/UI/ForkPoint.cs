using Dreamteck.Splines;
using Dreamteck.Splines.Examples;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ForkPoint : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private bool _isPointWithTutor;
    [SerializeField] private ForkTutor _forkTutorUI;
    [TextArea(1, 5)] [SerializeField] private string _leftSwitcherText;
    [TextArea(1, 5)] [SerializeField] private string _rightSwitcherText;
    [SerializeField] private SplineComputer _leftButtonLine;
    [SerializeField] private SplineComputer _rightButtonLine;
    [SerializeField] private Image _leftButtonImage;
    [SerializeField] private Image _rightButtonImage;

    public int Index => _index;
    public string LeftSwitcherText => _leftSwitcherText;
    public string RightSwitcherText => _rightSwitcherText;
    public SplineComputer LeftButtonLine => _leftButtonLine;
    public SplineComputer RightButtonLine => _rightButtonLine;
    public Image LeftButtonImage => _leftButtonImage;
    public Image RightButtonImage => _rightButtonImage;

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
