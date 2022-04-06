using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private int _currentLevelNumber;

    private void Awake()
    {
        Amplitude amplitude = Amplitude.Instance;
        amplitude.logging = true;
        amplitude.init("7a7794644f2d7cd030c2c521b4028a18");
        amplitude.LogLevelStart(_currentLevelNumber);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Level_" + _currentLevelNumber)
        {
            SceneTransition.SwitchToScene("StartMenu");
        }
    }

    public void GoToNextScene()
    {
        SceneTransition.SwitchToScene("Level_" + (_currentLevelNumber + 1));
    }

    public void Restart()
    {
        SceneTransition.SwitchToScene("Level_" + _currentLevelNumber);
    }
}
