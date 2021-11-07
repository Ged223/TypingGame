using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextProvider : MonoBehaviour
{
    public static TextProvider instance;
    void Awake()
    {
        if (instance != null)
            GameObject.Destroy(instance);
        else
            instance = this;

        //DontDestroyOnLoad(this); //uncomment this if you want to keep this script when another scene loads
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getNextWord()
    {
        return "placeholder";
    }
}
