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
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            GameObject.FindGameObjectWithTag("FirstMissionText").GetComponent<TMPro.TMP_Text>().SetText("Finish with 0 mistakes.\nCompleted: " + firstMissionDone.ToString());
            GameObject.FindGameObjectWithTag("SecondMissionText").GetComponent<TMPro.TMP_Text>().SetText("Finish with more frequent words.\nCompleted: " + secondMissionDone.ToString());
            GameObject.FindGameObjectWithTag("ThirdMissionText").GetComponent<TMPro.TMP_Text>().SetText("Finish with faster words.\nCompleted: " + thirdMissionDone.ToString());
            GameObject.FindGameObjectWithTag("FourthMissionText").GetComponent<TMPro.TMP_Text>().SetText("Finish with more words.\nCompleted: " + fourthMissionDone.ToString());
            GameObject.FindGameObjectWithTag("FifthMissionText").GetComponent<TMPro.TMP_Text>().SetText("Complete all of the above missions in a single attempt.\nCompleted: " + fifthMissionDone.ToString());

            GameObject.FindGameObjectWithTag("frwText").GetComponent<TMPro.TMP_Text>().SetText("Frequent words     /frw\n" + frequentWords.ToString());
            GameObject.FindGameObjectWithTag("fawText").GetComponent<TMPro.TMP_Text>().SetText("Fast words            /faw\n" + fasterWords.ToString());
            GameObject.FindGameObjectWithTag("mowText").GetComponent<TMPro.TMP_Text>().SetText("More words           /mow\n" + moreWords.ToString());

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
