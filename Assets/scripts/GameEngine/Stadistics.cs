using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class Stadistics : MonoBehaviour {
    public static float totalBullets, totalImpacts, finalLife, enemiesKilled;
    public static string lastPw, result;
    public static float level1Timer, aim;
    void Update() {
        level1Timer += 1 * Time.deltaTime;
    }
    public static void Level1() {
        aim = totalImpacts / totalBullets;
        Analytics.CustomEvent("Level 1", new Dictionary<string,object>{
            { "Total Bullets", totalBullets},
            { "Total Impacts", totalImpacts},
            { "AIM", aim},
            { "Enemies Killed", enemiesKilled},
            { "Last PW", lastPw},
            { "Result", result},
            { "Life", finalLife},
            { "Timer Level 1", level1Timer}
        });
    }
    public static void Level2() {
        aim = totalImpacts / totalBullets;
        Analytics.CustomEvent("Level 2", new Dictionary<string, object>{
            { "Total Bullets", totalBullets},
            { "Total Impacts", totalImpacts},
            { "AIM", aim},
            { "Enemies Killed", enemiesKilled},
            { "Last PW", lastPw},
            { "Result", result},
            { "Life", finalLife},
            { "Timer Level 1", level1Timer}
        });
    }
    public static void Challange() {
        aim = totalImpacts / totalBullets;
        Analytics.CustomEvent("Level 2", new Dictionary<string, object>{
            { "Total Bullets", totalBullets},
            { "Total Impacts", totalImpacts},
            { "AIM", aim},
            { "Enemies Killed", enemiesKilled},
            { "Last PW", lastPw},
            { "Result", result},
            { "Life", finalLife},
            { "Timer Level 1", level1Timer}
        });
    }
}
