using UnityEngine;

public class Progress : MonoBehaviour
{
    public int Level { get; private set; }
    public int AsyncLevel { get; private set; }
    public bool GameEnd { get; private set; }

    public static Progress Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        AsyncLevel = 5;
    }
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
            AsyncLevel = progressData.AsyncLevel;
            GameEnd = progressData.GameEnd;
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

    public void SetLevel(int level)
    {
        Level = level;
        Save();
    }

    public void SetEndGame()
    {
        GameEnd = true;
        Save();
    }

    public void IncreaseLevelAfterGameEnd(int value)
    {
        AsyncLevel += value;
        Save();
    }

    private void OnDestroy()
    {
        Save();
    }
}
