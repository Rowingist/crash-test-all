using UnityEngine;

public class TrainHandleButtons : MonoBehaviour
{
    [SerializeField] private GameObject _chooseTutor;

    private void OnEnable()
    {
        if (_chooseTutor)
        {
            _chooseTutor.SetActive(true);
        }
    }

    private void OnDisable()
    {
        if (_chooseTutor)
        {
            _chooseTutor.SetActive(false);
        }
    }
}
