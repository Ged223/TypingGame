using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferencesManager : MonoBehaviour
{
    const string first = "1";
    const string second = "2";
    const string third = "3";
    const string fourth = "4";
    const string fifth = "5";
    const string frw = "frw";
    const string faw = "faw";
    const string mow = "mow";
    void Start()
    {
        LoadPrefs();
    }

    private void OnApplicationQuit()
    {
        SavePrefs();
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetInt(first, (MissionManager.instance.firstMissionDone ? 1 : 0));
        PlayerPrefs.SetInt(second, (MissionManager.instance.secondMissionDone ? 1 : 0));
        PlayerPrefs.SetInt(third, (MissionManager.instance.thirdMissionDone ? 1 : 0));
        PlayerPrefs.SetInt(fourth, (MissionManager.instance.fourthMissionDone ? 1 : 0));
        PlayerPrefs.SetInt(fifth, (MissionManager.instance.fifthMissionDone ? 1 : 0));
        PlayerPrefs.SetInt(frw, (MissionManager.instance.frequentWords ? 1 : 0));
        PlayerPrefs.SetInt(faw, (MissionManager.instance.fasterWords ? 1 : 0));
        PlayerPrefs.SetInt(mow, (MissionManager.instance.moreWords ? 1 : 0));
    }

    public void LoadPrefs()
    {
        MissionManager.instance.firstMissionDone = (PlayerPrefs.GetInt(first) != 0);
        MissionManager.instance.secondMissionDone = (PlayerPrefs.GetInt(second) != 0);
        MissionManager.instance.thirdMissionDone = (PlayerPrefs.GetInt(third) != 0);
        MissionManager.instance.fourthMissionDone = (PlayerPrefs.GetInt(fourth) != 0);
        MissionManager.instance.fifthMissionDone = (PlayerPrefs.GetInt(fifth) != 0);
        MissionManager.instance.frequentWords = (PlayerPrefs.GetInt(frw) != 0);
        MissionManager.instance.fasterWords = (PlayerPrefs.GetInt(faw) != 0);
        MissionManager.instance.moreWords = (PlayerPrefs.GetInt(mow) != 0);
    }
}