using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmplitudeEvents : MonoBehaviour
{
    public const string GameStart = "game_start";
    public const string LevelStart = "level_start";
    public const string LevelComplete = "level_complete";
    public const string Fail = "fail";
    public const string Restart = "restart";
    public const string MainMenu = "main_menu";

    public static class Params
    {
        public const string Level = "level";
        public const string Reason = "reason";
        public const string TimeSpent = "time_spent";
    }
}
