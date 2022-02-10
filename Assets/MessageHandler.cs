using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MessageHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public TMPro.TMP_InputField inputField;

    [SerializeField]
    private GameObject orbManager;

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
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            SoundManager.PlaySound(SoundManager.Sound.CommandSubmitted);
            HandleMainMenuMessage(message);
        }
        else if (SceneManager.GetActiveScene().name == "MistakesLevel")
        {
            HandleMistakesLevelMessage(message);
        }
        else if (SceneManager.GetActiveScene().name == "GameOverMenu")
        {
            SoundManager.PlaySound(SoundManager.Sound.CommandSubmitted);
            HandleGameOverMenuMessage(message);
        }
        else if (SceneManager.GetActiveScene().name == "LevelCompleteMenu")
        {
            SoundManager.PlaySound(SoundManager.Sound.CommandSubmitted);
            HandleLevelCompleteMenuMessage(message);
        }
    }

    private void HandleMainMenuMessage(string message)
    {

        if (message == "/start" || message == "/play" || message == "/p")
        {
            SceneManager.LoadScene("MistakesLevel");
        }
        else if (message == "/quit" || message == "/q")
        {
            Application.Quit();
        }
        else if (message == "/frw")
        {
            TogglesManager.instance.frequentWords = !TogglesManager.instance.frequentWords;
        }
        else if (message == "/faw")
        {
            TogglesManager.instance.fasterWords = !TogglesManager.instance.fasterWords;
        }
        else if (message == "/mow")
        {
            TogglesManager.instance.moreWords = !TogglesManager.instance.moreWords;

        }
        else if (message == "/sfx")
        {
            TogglesManager.instance.soundEffects = !TogglesManager.instance.soundEffects;

        }
        else if (message == "/clearsave")
        {
            SoundManager.PlaySound(SoundManager.Sound.GameOver);
            PreferencesManager.ClearSave();
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
            SoundManager.PlaySound(SoundManager.Sound.CommandSubmitted);
            SceneManager.LoadScene("GameOverMenu");
        }
        else if (message == "/r" || message == "/restart")
        {
            SoundManager.PlaySound(SoundManager.Sound.CommandSubmitted);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            destroyTargetedEnemies(message);
        }
    }

    private void HandleLevelCompleteMenuMessage(string message)
    {
        if (message == "/quit" || message == "/q")
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (message == "/restart" || message == "/r")
        {
            SceneManager.LoadScene("MistakesLevel");
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

        StatsManager.handleSubmittedWord(message, (enemiesToRemove.Count >= 1));

        foreach (GameObject enemy in enemiesToRemove)
        {
            orbManager.GetComponent<OrbManager>().sendTarget(enemy);
        }

    }



}
