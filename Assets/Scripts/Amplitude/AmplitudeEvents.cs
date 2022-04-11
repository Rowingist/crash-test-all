using UnityEngine;

public class AmplitudeEvents : MonoBehaviour
{
    public const string GAME_START = "game_start";
    public const string LEVEL_START = "level_start";
    public const string LEVEL_COMPLETE = "level_complete";
    public const string FAIL = "fail";
    public const string RESTART = "restart";
    public const string MAIN_MENU = "main_menu";
    public const string SESSION_COUNT = "session_count";
    public const string REG_DAY = "reg_day";
    public const string DAYS_IN_GAME = "days_in_game";

    public static class Params
    {
        public const string COUNT = "count";
        public const string LEVEL = "level";
        public const string REASON = "reason";
        public const string TIME_SPENT = "time_spent";
        public const string KEY = "7a7794644f2d7cd030c2c521b4028a18";
    }
}
