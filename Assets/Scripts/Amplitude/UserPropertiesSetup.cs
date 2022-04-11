using System;
using UnityEngine;

public class UserPropertiesSetup : MonoBehaviour
{
    private const string FIRST_DAY = "first_day";

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt(FIRST_DAY) == 0)
        {
            int firstDay = DateTime.Today.Day;
            PlayerPrefs.SetInt(FIRST_DAY, firstDay);
        }

        if (PlayerPrefs.GetInt(AmplitudeEvents.Params.LEVEL) != 0)
            PlayerPrefs.SetInt(AmplitudeEvents.Params.LEVEL, 0);

        AmplitudeExtensions.InitAmplitude();
        SetRegDay();
        SetSessionsCount();
        SetDaysInGame();
        Amplitude.Instance.logEvent(AmplitudeEvents.MAIN_MENU);
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

        AmplitudeExtensions.SetRegDay(PlayerPrefs.GetString(regDay));
    }

    private void SetSessionsCount()
    {
        string sessionCount = AmplitudeEvents.SESSION_COUNT;
        int countStartSessions = PlayerPrefs.GetInt(sessionCount);
        countStartSessions++;

        PlayerPrefs.SetInt(sessionCount, countStartSessions);

        AmplitudeExtensions.SetGameStart(countStartSessions);
        AmplitudeExtensions.SetSessionCount(countStartSessions);
    }

    private void SetDaysInGame()
    {
        int currentDay = DateTime.Today.Day;
        string daysInGame = AmplitudeEvents.DAYS_IN_GAME;

        if (PlayerPrefs.GetInt(daysInGame) == 0)
        {
            PlayerPrefs.SetInt(daysInGame, 1);
            AmplitudeExtensions.SetDaysInGame(1);
        }

        if (currentDay != PlayerPrefs.GetInt(FIRST_DAY))
        {
            int days = PlayerPrefs.GetInt(daysInGame);
            days++;

            PlayerPrefs.SetInt(daysInGame, days);
            AmplitudeExtensions.SetDaysInGame(days);
        }
    }
}
