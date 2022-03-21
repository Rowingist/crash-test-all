using Dreamteck.Splines;
using TMPro;
using UnityEngine;

public class TrackHandleButton : MonoBehaviour
{
    private TMP_Text _buttonText;
    private SplineComputer _buttonLine;

    public SplineComputer ButtonLine => _buttonLine;

    private void Awake()
    {
        _buttonText = GetComponentInChildren<TMP_Text>();
    }

    public void SetButton(string lable, SplineComputer buttonLine)
    {
        _buttonText.text = lable;
        _buttonLine = buttonLine;
    }
}
