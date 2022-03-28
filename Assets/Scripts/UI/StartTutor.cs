using Dreamteck.Splines;
using Dreamteck.Splines.Examples;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class StartTutor : MonoBehaviour
{
    [SerializeField] private TrainMovement _train;
    [SerializeField] private GameLogic _game;
    [SerializeField] private Button _tutorButton;
    [SerializeField] private PlayableDirector _firstCutscene;
    [SerializeField] private PlayableDirector _secondCutscene;
    [SerializeField] private float _cutscenesTransition;

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
        Invoke(nameof(ChangeTimeline), _cutscenesTransition);
        StartCoroutine(_train.ChangeSpeed(0, _game.TrainStartSpeed, 4f));
        _tutorButton.gameObject.SetActive(false);
    }

    private void ChangeTimeline()
    {
        _firstCutscene.Stop();
        _secondCutscene.Play();
    }
}
