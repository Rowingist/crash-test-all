using Dreamteck.Splines;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrackHandleButton : MonoBehaviour
{
    private TMP_Text _buttonText;
    private SplineComputer _buttonLine;
    private Image _buttonImage;

    public SplineComputer ButtonLine => _buttonLine;

    private void Awake()
    {
        _buttonText = GetComponentInChildren<TMP_Text>();
        _buttonImage = GetComponent<Image>();
    }

    public void SetButton(Image image, string lable)
    {
        _buttonText.text = lable;
        _buttonImage = image;
    }
}
