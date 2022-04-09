using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private int _currentLevelNumber;
    [SerializeField] private Progress _progress;

    private Amplitude _amplitude;
    private const string FIRST_DAY = "first_day";
    private void Awake()
    {
        _progress.Load();
        _amplitude = Amplitude.Instance;
        _amplitude.logging = true;
        _amplitude.init("7a7794644f2d7cd030c2c521b4028a18");
        AssertStartAnalitics();
        _progress.Save();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Level_" + _currentLevelNumber)
        {
            SceneTransition.SwitchToScene("StartMenu");
            _progress.SetLevel(_currentLevelNumber);
            _progress.Save();
        }
    }

    public void GoToNextScene()
    {
        if (_currentLevelNumber == 0)
        {
            if (_progress.Level > 0)
            {
                SceneTransition.SwitchToScene("Level_" + (_progress.Level));
            }
            else
            {
                SwitchToNextLevel();
            }
        }
        else
        {
            SwitchToNextLevel();
        }

        if (_currentLevelNumber < 5)
        {
            _amplitude.LogLevelComplete(_currentLevelNumber, Mathf.RoundToInt(Time.timeSinceLevelLoad));
        }
        _progress.Save();
    }

    private void SwitchToNextLevel()
    {
        int nextLevel = 1;
        if (_currentLevelNumber != 5)
        {
            nextLevel = _currentLevelNumber + 1;  
        }

        SceneTransition.SwitchToScene("Level_" + (nextLevel));
        _progress.SetLevel(nextLevel);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneTransition.SwitchToScene("Level_" + _currentLevelNumber);
        _amplitude.LogLevelRestart(_currentLevelNumber);
    }

    private void AssertStartAnalitics()
    {
        if (_currentLevelNumber == 0)
        {
            _progress.IncreaseGameStartsCount();
            var gameStartArguments = new Dictionary<string, object>
            {
                {AmplitudeEvents.Params.COUNT, _progress.GameStartsCount}
            };
            _amplitude.logEvent(AmplitudeEvents.GAME_START, gameStartArguments);

            _amplitude.logEvent(AmplitudeEvents.MAIN_MENU);
        }
        else if (_progress.Level > 0)
        {
            _amplitude.LogLevelStart(_progress.Level);
        }
    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt(FIRST_DAY) == 0)
        {
            int firstDay = DateTime.Today.Day;
            PlayerPrefs.SetInt(FIRST_DAY, firstDay);
        }

        if (PlayerPrefs.GetInt(AmplitudeEvents.Params.LEVEL) == 0)
            PlayerPrefs.SetInt(AmplitudeEvents.Params.LEVEL, 1);

        SetRegDay();
        SetDaysInGame();
        SetCountSessions();
    }

    private void SetCountSessions()
    {
        string sessionCount = AmplitudeEvents.SESSION_COUNT;
        int countStartSessions = PlayerPrefs.GetInt(sessionCount);
        countStartSessions++;

        PlayerPrefs.SetInt(sessionCount, countStartSessions);

        _amplitude.SetSessionCount(countStartSessions);
    }

    private void SetDaysInGame()
    {
        int currentDay = DateTime.Today.Day;
        string daysInGame = AmplitudeEvents.DAYS_IN_GAME;

        if (PlayerPrefs.GetInt(daysInGame) == 0)
        {
            PlayerPrefs.SetInt(daysInGame, 1);
            _amplitude.SetDaysInGame(1);
        }

        if (currentDay != PlayerPrefs.GetInt(FIRST_DAY))
        {
            int days = PlayerPrefs.GetInt(daysInGame);
            days++;

            PlayerPrefs.SetInt(daysInGame, days);
            _amplitude.SetDaysInGame(days);
        }
    }
    private void SetRegDay()
    {
        int True = 1;
        string regDay = AmplitudeEvents.REG_DAY;

        DateTime dateTime = DateTime.Now;
        string date = dateTime.ToString();

        if (PlayerPrefs.GetInt(regDay) != True)
        {
            PlayerPrefs.SetInt(regDay, True);
            PlayerPrefs.SetString(regDay, date);
        }

        _amplitude.SetRegDay(PlayerPrefs.GetString(regDay));
    }
}
