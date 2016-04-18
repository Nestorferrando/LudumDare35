using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Control {
    private static int missionIndex = 2;
    private static readonly string[] missions = { "mission0", "mission0b", "mission1", "mission1b", "mission2", "mission2b", "mission3", "mission3b", "mission4", "mission4b" };

    public static HashSet<string> currentTags = new HashSet<string>();
    public static bool infiltration = false;

    public static string nextMission() {
        if (missionIndex == missions.Length-1) {
            return "final";
        }
        return missions[++missionIndex];
    }

    public static string currentMission() {
        return missions[missionIndex];
    }

    public static string prevMission() {
        if (missionIndex == 0) {
            return "mission0";
        }
        return missions[--missionIndex];
    }
}