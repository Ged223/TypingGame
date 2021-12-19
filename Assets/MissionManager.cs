using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instance;
    public bool firstMissionDone = false;
    public bool secondMissionDone = false;
    public bool thirdMissionDone = false;
    public bool fourthMissionDone = false;
    public bool fifthMissionDone = false;
    public bool frequentWords = false;
    public bool fasterWords = false;
    public bool moreWords = false;
    private void Awake()
    {

        if (instance != null)
            GameObject.Destroy(instance);
        else
            instance = this;
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            //TODO HERE at the loading of main menu, update the text to display completeness of missions
        }
    }

    public void CheckMissionConditions()
    {
        if (firstMissionCondition())
        {
            firstMissionDone = true;
        }
        if (secondMissionCondition())
        {
            secondMissionDone = true;
        }
        if (thirdMissionCondition())
        {
            thirdMissionDone = true;
        }
        if (fourthMissionCondition())
        {
            fourthMissionDone = true;
        }
        if (fifthMissionCondition())
        {
            fifthMissionDone = true;
        }
    }

    private bool firstMissionCondition()
    {
        return StatsManager.mistakes == 0;
    }

    private bool secondMissionCondition()
    {
        return frequentWords;
    }

    private bool thirdMissionCondition()
    {
        return fasterWords;
    }

    private bool fourthMissionCondition()
    {
        return moreWords;
    }

    private bool fifthMissionCondition()
    {
        return firstMissionCondition() && secondMissionCondition() && thirdMissionCondition() && fourthMissionCondition();
    }
}
