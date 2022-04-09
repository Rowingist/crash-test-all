using System.Collections.Generic;

public static class AmplitudeExtensions
{
    public static void LogLevelStart(this Amplitude amplitude, int level)
    {
        var eventArguments = new Dictionary<string, object>
            {
                {AmplitudeEvents.Params.LEVEL, level}
            };
        amplitude.logEvent(AmplitudeEvents.LEVEL_START, eventArguments);
    }

    public static void LogLevelRestart(this Amplitude amplitude, int level)
    {
        var eventArguments = new Dictionary<string, object>
            {
                {AmplitudeEvents.Params.LEVEL, level}
            };
        amplitude.logEvent(AmplitudeEvents.RESTART, eventArguments);
    }

    public static void LogLevelComplete(this Amplitude amplitude, int level, int secondsSpent)
    {
        var eventArguments = new Dictionary<string, object>
            {
                {AmplitudeEvents.Params.LEVEL, level},
                {AmplitudeEvents.Params.TIME_SPENT, secondsSpent}
            };
        amplitude.logEvent(AmplitudeEvents.LEVEL_COMPLETE, eventArguments);
    }

    public static void SetSessionCount(this Amplitude amplitude, int count)
    {
        amplitude.setUserProperty(AmplitudeEvents.SESSION_COUNT, count);
    }

    public static void SetRegDay(this Amplitude amplitude, string date)
    {
        amplitude.setUserProperty(AmplitudeEvents.REG_DAY, date);
    }

    public static void SetDaysInGame(this Amplitude amplitude, int count)
    {
        amplitude.setUserProperty(AmplitudeEvents.DAYS_IN_GAME, count);
    }


}
