using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private float _traiStartSpeed;
    [SerializeField] private TrainHandleButtons _playHandleButtons;
    [SerializeField] private ForkPoint[] _forkPoints;
    [SerializeField] private GameObject _startTutor;

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
        _playHandleButtons.Left.SetButton(reachePoint.LeftButtonImage, reachePoint.LeftSwitcherText);
        _playHandleButtons.Right.SetButton(reachePoint.RightButtonImage, reachePoint.RightSwitcherText);
    }
}
