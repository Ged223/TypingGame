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
    const string sfx = "sfx";
    void Start()
    {
        LoadPrefs();
    }

    private void OnApplicationQuit()
    {
        SavePrefs();
    }

    public static void SavePrefs()
    {
        PlayerPrefs.SetInt(first, (TogglesManager.instance.firstMissionDone ? 1 : 0));
        PlayerPrefs.SetInt(second, (TogglesManager.instance.secondMissionDone ? 1 : 0));
        PlayerPrefs.SetInt(third, (TogglesManager.instance.thirdMissionDone ? 1 : 0));
        PlayerPrefs.SetInt(fourth, (TogglesManager.instance.fourthMissionDone ? 1 : 0));
        PlayerPrefs.SetInt(fifth, (TogglesManager.instance.fifthMissionDone ? 1 : 0));
        PlayerPrefs.SetInt(frw, (TogglesManager.instance.frequentWords ? 1 : 0));
        PlayerPrefs.SetInt(faw, (TogglesManager.instance.fasterWords ? 1 : 0));
        PlayerPrefs.SetInt(mow, (TogglesManager.instance.moreWords ? 1 : 0));
        PlayerPrefs.SetInt(sfx, (TogglesManager.instance.soundEffects ? 0 : 1));//inverted storage, 0 is true
        //because default value needs to be true, and if loaded without existing save file, it loads 0(which now means true)
    }

    public static void LoadPrefs()
    {
        TogglesManager.instance.firstMissionDone = (PlayerPrefs.GetInt(first) != 0);
        TogglesManager.instance.secondMissionDone = (PlayerPrefs.GetInt(second) != 0);
        TogglesManager.instance.thirdMissionDone = (PlayerPrefs.GetInt(third) != 0);
        TogglesManager.instance.fourthMissionDone = (PlayerPrefs.GetInt(fourth) != 0);
        TogglesManager.instance.fifthMissionDone = (PlayerPrefs.GetInt(fifth) != 0);
        TogglesManager.instance.frequentWords = (PlayerPrefs.GetInt(frw) != 0);
        TogglesManager.instance.fasterWords = (PlayerPrefs.GetInt(faw) != 0);
        TogglesManager.instance.moreWords = (PlayerPrefs.GetInt(mow) != 0);
        TogglesManager.instance.soundEffects = (PlayerPrefs.GetInt(sfx) == 0);//inverted storage, 0 is true
        //because default value needs to be true, and if loaded without existing save file, it loads 0(which now means true)
    }

    public static void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        LoadPrefs();//load the factory option
    }
}