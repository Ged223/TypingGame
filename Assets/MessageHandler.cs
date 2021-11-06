using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MessageHandler : MonoBehaviour
{
    // Start is called before the first frame update
    // [SerializeField] - dont know what this does
    public TMPro.TMP_InputField inputField;

    private void Start()
    {
        inputField.onEndEdit.AddListener(val =>
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))//to only submit when press enter, not when unselect for any reason
            {
                Debug.Log(inputField.GetComponentInChildren<TMPro.TMP_InputField>().text);
                inputField.text = "";
                inputField.GetComponentInChildren<TMPro.TMP_InputField>().ActivateInputField();
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
