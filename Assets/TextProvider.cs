using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TextProvider : MonoBehaviour
{
    public static TextProvider instance;
    private string wordsInSentences = "Phasellu vi sem ";//aliquam, feugiat tortor vel, varius tellus. Quisque vel consectetur mauris, nec mollis elit. Vestibulum ornare diam ut nibh molestie posuere.";// Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Morbi quis porttitor justo, a dictum purus. Aenean volutpat, orci consectetur euismod bibendum, nunc ipsum feugiat felis, vitae porta augue tellus in nulla. Aenean eleifend hendrerit mi. Vestibulum nec imperdiet enim, quis iaculis magna. Vivamus suscipit vitae urna et mattis. Donec ultrices id neque at cursus. Maecenas varius tellus nunc, accumsan accumsan purus volutpat a. Cras a tortor feugiat, lacinia enim ac, tincidunt augue. Nam id sollicitudin tortor. Fusce metus felis, molestie non ultrices placerat, sollicitudin porttitor justo. Duis at magna non mauris malesuada lobortis.";
    private List<string> wordsInList;
    private int nextWordIndex;
    void Awake()
    {
        if (instance != null)
            GameObject.Destroy(instance);
        else
            instance = this;
        //DontDestroyOnLoad(this); //uncomment this if you want to keep this script when another scene loads

        wordsInList = new List<string>(wordsInSentences.Split(' '));
        nextWordIndex = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        StatsManager.reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getNextWord()
    {
        if(nextWordIndex >= wordsInList.Count)
        {
            if(EnemySpawner.spawnedEnemies.Count == 0)
            {
                MissionManager.instance.CheckMissionConditions();
                SceneManager.LoadScene("LevelCompleteMenu");
            }
            else
            {
                return "";
            }

        }
        else
        {
            string nextWord = wordsInList[nextWordIndex];
            nextWordIndex++;
            return nextWord;
        }
        return "";
    }

    
}
