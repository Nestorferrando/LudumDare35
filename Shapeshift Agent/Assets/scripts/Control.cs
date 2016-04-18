using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Control {
    private static int missionIndex = 0;
    private static readonly string[] missions = { "mission0", "mission0b", "mission1", "mission1b", "mission2", "mission2b", "mission3", "mission3b", "mission4", "mission4b" };

    public static HashSet<string> currentTags = new HashSet<string>();
    private static HashSet<string> traitFailTags = new HashSet<string>(); 
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

    public enum TraitFail { HAIR, FACECOLOR, EYE, NOSE, MOUTH }
    public static void addTraitFailTag(TraitFail t) {
        switch(t) {
            case TraitFail.HAIR:
                Control.currentTags.Add(Control.currentMission() + "hairfail");
                Control.traitFailTags.Add(Control.currentMission() + "hairfail");
                break;
            case TraitFail.FACECOLOR:
                Control.currentTags.Add(Control.currentMission() + "facefail");
                Control.traitFailTags.Add(Control.currentMission() + "facefail");
                break;
            case TraitFail.EYE:
                Control.currentTags.Add(Control.currentMission() + "eyefail");
                Control.traitFailTags.Add(Control.currentMission() + "eyefail");
                break;
            case TraitFail.NOSE:
                Control.currentTags.Add(Control.currentMission() + "nosefail");
                Control.traitFailTags.Add(Control.currentMission() + "nosefail");
                break;
            case TraitFail.MOUTH:
                Control.currentTags.Add(Control.currentMission() + "mouthfail");
                Control.traitFailTags.Add(Control.currentMission() + "mouthfail");
                break;
        }
    }

    public static void eraseTraitFailTag() {
        foreach (string t in traitFailTags) {
            currentTags.Remove(t);
        }
    }
}