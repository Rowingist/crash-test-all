using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private Progress _progress;

    private void Start()
    {
        if (_progress.Level == 0)
        {
            _lable.text = "";
        }
        else
        {
            _lable.text = "Level " + _progress.Level.ToString();
        }
    }
}
