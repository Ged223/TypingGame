using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StatsManager
{
    public static int totalCharacters = 0;
    public static int correctCharacters = 0;
    public static double percentageCorrect = 0;

    public static void handleSubmittedWord(string message, bool correct)
    {
        totalCharacters += message.Length;
        if (correct)
        {
            correctCharacters += message.Length;
        }
        percentageCorrect = correctCharacters / ((double) totalCharacters / 100);
        Debug.Log("percent correct: " + percentageCorrect);
    }

    public static void reset()
    {
        totalCharacters = 0;
        correctCharacters = 0;
        percentageCorrect = 0;
    }
}
