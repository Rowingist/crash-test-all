using Dreamteck.Splines;
using Dreamteck.Splines.Examples;
using UnityEngine;
using UnityEngine.UI;

public class StartTutor : MonoBehaviour
{
    [SerializeField] private TrainMovement _train;
    [SerializeField] private GameLogic _game;
    [SerializeField] private Button _tutorButton;

    private void OnEnable()
    {
        _tutorButton.onClick.AddListener(OnDepartueTrain);
    }

    private void OnDisable()
    {
        _tutorButton.onClick.RemoveListener(OnDepartueTrain);
    }

    private void OnDepartueTrain()
    {
        StartCoroutine(_train.ChangeSpeed(0, _game.TrainStartSpeed, 4f));
        _tutorButton.gameObject.SetActive(false);
    }
}
