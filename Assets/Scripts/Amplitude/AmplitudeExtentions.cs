using System.Collections.Generic;

public static class AmplitudeExtensions
{
    public static void InitAmplitude()
    {
        Amplitude amplitude = Amplitude.getInstance();
        amplitude.setServerUrl("https://api2.amplitude.com");
        amplitude.logging = true;
        amplitude.trackSessionEvents(true);
        amplitude.init(AmplitudeEvents.Params.KEY);
    }

    public static void SetGameStart(int count)
    {

        Dictionary<string, object> eventArguments = new Dictionary<string, object>
        {
            {AmplitudeEvents.Params.COUNT, count}
        };

        Amplitude.Instance.logEvent(AmplitudeEvents.GAME_START, eventArguments);
    }

    public static void SetLevelStart(int level)
    {
        var eventArguments = new Dictionary<string, object>
            {
                {AmplitudeEvents.Params.LEVEL, level}
            };
        Amplitude.Instance.logEvent(AmplitudeEvents.LEVEL_START, eventArguments);
    }

    public static void SetLevelRestart(int level)
    {
        var eventArguments = new Dictionary<string, object>
            {
                {AmplitudeEvents.Params.LEVEL, level}
            };
        Amplitude.Instance.logEvent(AmplitudeEvents.RESTART, eventArguments);
    }

    public static void SetLevelComplete(int level, int secondsSpent)
    {
        var eventArguments = new Dictionary<string, object>
            {
                {AmplitudeEvents.Params.LEVEL, level},
                {AmplitudeEvents.Params.TIME_SPENT, secondsSpent}
            };
        Amplitude.Instance.logEvent(AmplitudeEvents.LEVEL_COMPLETE, eventArguments);
    }

    public static void SetSessionCount(int count)
    {
        Amplitude.Instance.setUserProperty(AmplitudeEvents.SESSION_COUNT, count);
    }

    public static void SetRegDay(string date)
    {
        Amplitude.Instance.setUserProperty(AmplitudeEvents.REG_DAY, date);
    }

    public static void SetDaysInGame(int count)
    {
        Amplitude.Instance.setUserProperty(AmplitudeEvents.DAYS_IN_GAME, count);
    }
}
