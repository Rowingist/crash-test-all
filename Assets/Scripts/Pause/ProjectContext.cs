using UnityEngine;

public class ProjectContext : MonoBehaviour
{
    public PauseManager PauseManager { get; private set; }
    public static ProjectContext Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        PauseManager = new PauseManager();
    }
}
