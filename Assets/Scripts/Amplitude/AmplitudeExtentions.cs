using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AmplitudeExtensions
{
    public static void LogLevelStart(this Amplitude amplitude, int level)
    {
        var eventArguments = new Dictionary<string, object>
            {
                {AmplitudeEvents.Params.Level, level}
            };
        amplitude.logEvent(AmplitudeEvents.LevelStart, eventArguments);
    }

    public static void LogLevelRestart(this Amplitude amplitude, int level)
    {
        var eventArguments = new Dictionary<string, object>
            {
                {AmplitudeEvents.Params.Level, level}
            };
        amplitude.logEvent(AmplitudeEvents.Restart, eventArguments);
    }

    public static void LogLevelComplete(this Amplitude amplitude, int level, int secondsSpent)
    {
        var eventArguments = new Dictionary<string, object>
            {
                {AmplitudeEvents.Params.Level, level},
                {AmplitudeEvents.Params.TimeSpent, secondsSpent}
            };
        amplitude.logEvent(AmplitudeEvents.LevelComplete, eventArguments);
    }

    public static void LogLevelFail(this Amplitude amplitude, int level, string reason, int secondsSpent)
    {
        var eventArguments = new Dictionary<string, object>
            {
                {AmplitudeEvents.Params.Level, level},
                {AmplitudeEvents.Params.Reason, reason},
                {AmplitudeEvents.Params.TimeSpent, secondsSpent}
            };
        amplitude.logEvent(AmplitudeEvents.Fail, eventArguments);
    }
}
