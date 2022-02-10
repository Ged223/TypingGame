using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TogglesManager : MonoBehaviour
{
    public static TogglesManager instance;
    public bool firstMissionDone = false;
    public bool secondMissionDone = false;
    public bool thirdMissionDone = false;
    public bool fourthMissionDone = false;
    public bool fifthMissionDone = false;
    public bool frequentWords = false;
    public bool fasterWords = false;
    public bool moreWords = false;
    public bool soundEffects = true;
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
            GameObject.FindGameObjectWithTag("FirstMissionText").GetComponent<TMPro.TMP_Text>().color = firstMissionDone ? Color.green : Color.red;
            GameObject.FindGameObjectWithTag("SecondMissionText").GetComponent<TMPro.TMP_Text>().SetText("Finish with more frequent words.\nCompleted: " + secondMissionDone.ToString());
            GameObject.FindGameObjectWithTag("SecondMissionText").GetComponent<TMPro.TMP_Text>().color = secondMissionDone ? Color.green : Color.red;
            GameObject.FindGameObjectWithTag("ThirdMissionText").GetComponent<TMPro.TMP_Text>().SetText("Finish with faster words.\nCompleted: " + thirdMissionDone.ToString());
            GameObject.FindGameObjectWithTag("ThirdMissionText").GetComponent<TMPro.TMP_Text>().color = thirdMissionDone ? Color.green : Color.red;
            GameObject.FindGameObjectWithTag("FourthMissionText").GetComponent<TMPro.TMP_Text>().SetText("Finish with more words.\nCompleted: " + fourthMissionDone.ToString());
            GameObject.FindGameObjectWithTag("FourthMissionText").GetComponent<TMPro.TMP_Text>().color = fourthMissionDone ? Color.green : Color.red;
            GameObject.FindGameObjectWithTag("FifthMissionText").GetComponent<TMPro.TMP_Text>().SetText("Complete all of the above missions in a single attempt.\nCompleted: " + fifthMissionDone.ToString());
            GameObject.FindGameObjectWithTag("FifthMissionText").GetComponent<TMPro.TMP_Text>().color = fifthMissionDone ? Color.green : Color.red;

            GameObject.FindGameObjectWithTag("frwText").GetComponent<TMPro.TMP_Text>().SetText("Frequent words     /frw\n" + frequentWords.ToString());
            GameObject.FindGameObjectWithTag("frwText").GetComponent<TMPro.TMP_Text>().color = frequentWords ? Color.green : Color.red;
            GameObject.FindGameObjectWithTag("fawText").GetComponent<TMPro.TMP_Text>().SetText("Fast words            /faw\n" + fasterWords.ToString());
            GameObject.FindGameObjectWithTag("fawText").GetComponent<TMPro.TMP_Text>().color = fasterWords ? Color.green : Color.red;
            GameObject.FindGameObjectWithTag("mowText").GetComponent<TMPro.TMP_Text>().SetText("More words           /mow\n" + moreWords.ToString());
            GameObject.FindGameObjectWithTag("mowText").GetComponent<TMPro.TMP_Text>().color = moreWords ? Color.green : Color.red;
            GameObject.FindGameObjectWithTag("sfxText").GetComponent<TMPro.TMP_Text>().SetText("Sound Effects	/sfx\n" + soundEffects.ToString());
            GameObject.FindGameObjectWithTag("sfxText").GetComponent<TMPro.TMP_Text>().color = soundEffects ? Color.green : Color.red;

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
