using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSequence : MonoBehaviour
{
    private bool _gameEnd => Progress.Instance.GameEnd;
    private int _currentScene => SceneManager.GetActiveScene().buildIndex;

    private void Start()
    {
        Progress.Instance.Load();
        if (_currentScene != 0)
        {
            if (_gameEnd)
                AmplitudeExtensions.SetLevelStart(Progress.Instance.AsyncLevel);
            else
                AmplitudeExtensions.SetLevelStart(_currentScene);
        }
    }

    public void NextScene()
    {
        if (_gameEnd)
        {
            AmplitudeExtensions.SetLevelComplete(Progress.Instance.AsyncLevel, Mathf.RoundToInt(Time.timeSinceLevelLoad));

            if (_currentScene != 0)
            {
                Progress.Instance.IncreaseLevelAfterGameEnd(1);
                int rand = Random.Range(1, 5);
                Progress.Instance.SetLevel(rand);
            }

            SceneTransition.SwitchToScene("Level_" + Progress.Instance.Level);
            return;
        }

        if (_currentScene == 5)
        {
            AmplitudeExtensions.SetLevelComplete(_currentScene, Mathf.RoundToInt(Time.timeSinceLevelLoad));
            Progress.Instance.SetEndGame();
            Progress.Instance.IncreaseLevelAfterGameEnd(1);
            int rand = Random.Range(1, 4);
            Progress.Instance.SetLevel(rand);
            SceneTransition.SwitchToScene("Level_" + Progress.Instance.Level);
            return;
        }

        if (_currentScene == 0)
        {
            if (!_gameEnd)
            {
                if (Progress.Instance.Level == 0)
                    Progress.Instance.SetLevel(1);
                else
                    Progress.Instance.SetLevel(Progress.Instance.Level);
            }
            else
            {
                SceneTransition.SwitchToScene("Level_" + Progress.Instance.AsyncLevel);
                return;
            }
        }
        else
        {
            Progress.Instance.SetLevel(_currentScene + 1);
            AmplitudeExtensions.SetLevelComplete(_currentScene, Mathf.RoundToInt(Time.timeSinceLevelLoad));
        }
        SceneTransition.SwitchToScene("Level_" + Progress.Instance.Level);
    }

    public void LoadMainMenu()
    {
        SceneTransition.SwitchToScene("Level_" + 0);
    }

    public void Restart()
    {
        SceneTransition.SwitchToScene("Level_" + _currentScene);

        if (_gameEnd)
            AmplitudeExtensions.SetLevelRestart(Progress.Instance.AsyncLevel);
        else
            AmplitudeExtensions.SetLevelRestart(_currentScene);
    }
}
