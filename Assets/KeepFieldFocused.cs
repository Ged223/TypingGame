using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepFieldFocused : MonoBehaviour
{   
    public TMPro.TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputField.Select();
    }
}