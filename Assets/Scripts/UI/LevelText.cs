using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;

    private void Start()
    {
        if (Progress.Instance.Level == 0)
        {
            _lable.text = "";
        }
        else
        {
            if (Progress.Instance.GameEnd)
                _lable.text = "Level " + Progress.Instance.AsyncLevel;

            else
                _lable.text = "Level " + Progress.Instance.Level.ToString();
        }
    }
}
