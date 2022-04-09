using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public int GameStartsCount { get; private set; }
    public int Level { get; private set; }

    public void Save()
    {
        SaveSystem.Save(this);
    }

    public void Load()
    {
        ProgressData progressData = SaveSystem.Load();
        if (progressData != null)
        {
            Level = progressData.Llevel;
            GameStartsCount = progressData.GameStartsCount;
        }
        else
        {
            Level = 0;
        }
    }

    [ContextMenu("Delete Saved")]
    public void DeleteFile()
    {
        SaveSystem.DeleteFile();
    }

    public void SetLevel(int value)
    {
        Level = value;
    }

    public void IncreaseGameStartsCount()
    {
        GameStartsCount += 1;
    }
}
