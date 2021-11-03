using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    // Start is called before the first frame update
    // [SerializeField] - dont know what this does
    public TMPro.TMP_InputField inputField;

    private void Start()
    {
        inputField.onEndEdit.AddListener(val =>
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                Debug.Log(inputField.GetComponentInChildren<TMPro.TMP_InputField>().text);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
