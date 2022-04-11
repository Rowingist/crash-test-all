using TMPro;
using UnityEngine;

public class NextLevelText : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;

    private bool IsPaused => ProjectContext.Instance.PauseManager.IsPaused;

    private void Update()
    {
        _lable.text = IsPaused ? "Tap play button" : "Tap to continue";
    }
}
