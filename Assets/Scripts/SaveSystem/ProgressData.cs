[System.Serializable]
public class ProgressData
{
    public int GameStartsCount { get; private set; }
    public int Llevel { get; private set; }

    public ProgressData(Progress progress)
    {
        GameStartsCount += progress.GameStartsCount;
        Llevel = progress.Level;
    }
}
