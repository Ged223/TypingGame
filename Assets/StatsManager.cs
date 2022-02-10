using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StatsManager
{
    public static int totalCharacters = 0;
    public static int correctCharacters = 0;
    public static int mistakes = 0;

    public static void handleSubmittedWord(string message, bool correct)
    {
        if (!correct)
        {
            SoundManager.PlaySound(SoundManager.Sound.Mistake);
            mistakes = mistakes + 1;
        }
    }

    public static void reset()
    {
        totalCharacters = 0;
        correctCharacters = 0;
        mistakes = 0;
    }
}
