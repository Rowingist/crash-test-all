using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private float _traiStartSpeed;
    [SerializeField] private TrainHandleButtons _playHandleButtons;
    [SerializeField] private ForkPoint[] _forkPoints;
    [SerializeField] private StartTutor _startTutor;

    private List<ForkPoint> _forkPointsList = new List<ForkPoint>();
    public float TrainStartSpeed => _traiStartSpeed;

    private void OnEnable()
    {
        _startTutor.gameObject.SetActive(true);
        for (int i = 0; i < _forkPoints.Length; i++)
        {
            _forkPoints[i].Reached += OnActivateHandleButtons;
            _forkPointsList.Add(_forkPoints[i]);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _forkPoints.Length; i++)
        {
            _forkPoints[i].Reached += OnActivateHandleButtons;
        }
    }

    private void OnActivateHandleButtons(ForkPoint reachePoint)
    {
        Time.timeScale = 0.01f;
        _playHandleButtons.gameObject.SetActive(true);
        _playHandleButtons.Left.SetButton(reachePoint.LeftSwitcherText, reachePoint.LeftButtonLine);
        _playHandleButtons.Right.SetButton(reachePoint.RightSwitcherText, reachePoint.RightButtonLine);
    }
}
