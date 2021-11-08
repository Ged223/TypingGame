using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                string message = inputField.GetComponentInChildren<TMPro.TMP_InputField>().text;
                inputField.text = "";
                inputField.GetComponentInChildren<TMPro.TMP_InputField>().ActivateInputField();
                HandleMessage(message);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandleMessage(string message)
    {
        Debug.Log(message);
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            HandleMainMenuMessage(message);
        }
        else if(SceneManager.GetActiveScene().name == "MistakesLevel")
        {
            HandleMistakesLevelMessage(message);
        }
        else if (SceneManager.GetActiveScene().name == "GameOverMenu")
        {
            HandleGameOverMenuMessage(message);
        }
        else if (SceneManager.GetActiveScene().name == "LevelCompleteMenu")
        {
            HandleLevelCompleteMenuMessage(message);
        }
    }

    private void HandleMainMenuMessage(string message)
    {
        if(message == "/start" || message == "/play")
        {
            SceneManager.LoadScene("MistakesLevel");
        }
        else if(message == "/quit" || message == "/q")
        {
            Application.Quit();
        }

    }
    private void HandleGameOverMenuMessage(string message)
    {
        if (message == "/start" || message == "/play" || message == "/restart" || message == "/r")
        {
            SceneManager.LoadScene("MistakesLevel");
        }
        else if (message == "/menu" || message == "/quit" || message == "/q")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void HandleMistakesLevelMessage(string message)
    {
        if (message == "/quit" || message == "/q")
        {
            SceneManager.LoadScene("GameOverMenu");
        } 
        else
        {
            destroyTargetedEnemies(message);
        }
    }

    private void destroyTargetedEnemies(string message)
    {
        List<GameObject> enemiesToRemove = new List<GameObject>();
        foreach (GameObject enemy in EnemySpawner.spawnedEnemies)
        {
            if (enemy.GetComponentInChildren<TextMesh>().text == message)
            {
                enemiesToRemove.Add(enemy);
            }
        }
        foreach (GameObject enemy in enemiesToRemove)
        {
            EnemySpawner.spawnedEnemies.Remove(enemy);
            GameObject.Destroy(enemy);
        }
    }

    private void HandleLevelCompleteMenuMessage(string message)
    {
        if (message == "/quit" || message == "/q")
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if(message == "/restart" || message == "/r")
        {
            SceneManager.LoadScene("MistakesLevel");
        }
        
    }


}
