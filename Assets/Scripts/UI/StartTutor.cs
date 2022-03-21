using Dreamteck.Splines;
using Dreamteck.Splines.Examples;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartTutor : MonoBehaviour
{
    [SerializeField] private TrainEngine _train;
    [SerializeField] private GameLogic _game;
    
    private Button _tutorButton;

    private void Awake()
    {
        _tutorButton = GetComponent<Button>();
    }

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
        _train.GetComponent<SplineFollower>().followSpeed = _game.TrainStartSpeed;
        gameObject.SetActive(false);
    }
}
