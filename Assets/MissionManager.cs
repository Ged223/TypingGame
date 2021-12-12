using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instance;
    public bool firstMissionDone = false;
    public bool secondMissionDone = false;
    public bool thirdMissionDone = false;
    public bool fourthMissionDone = false;
    public bool fifthMissionDone = false;
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
        
    }
}
