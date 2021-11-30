using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsToText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInParent<TextMeshProUGUI>().SetText("Mistakes: "+StatsManager.mistakes);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
