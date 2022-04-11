[System.Serializable]
public class ProgressData
{
    public int Llevel { get; private set; }
    public int AsyncLevel { get; private set; }
    public bool GameEnd { get; private set; }


    public ProgressData(Progress progress)
    {
        Llevel = progress.Level;
        AsyncLevel = progress.AsyncLevel;
        GameEnd = progress.GameEnd;
    }
}
