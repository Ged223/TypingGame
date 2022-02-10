using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TextProvider : MonoBehaviour
{
    public static TextProvider instance;
    private string[] textsAvailable =
        {
        //source of texts: https://typeracerdata.com/texts?texts=full&sort=length
        "A straight line is said to have been cut in extreme and mean ratio when, as the whole line is to the greater segment, so is the greater to the lesser.",
        "Our worst fears, like our greatest hopes, are not outside our powers, and we can come in the end to triumph over the former and to achieve the latter.",
        "You know, Michael; now that you're so respectable, I think you're more dangerous than ever. I liked you better when you were just a common Mafia hood.",
        "You were the chosen one! It was said that you would destroy the Sith, not join them. You were to bring balance to the Force, not leave it in darkness.",
        "Don't look back, keep your head held high. Don't ask them why because life is short and before you know you're feeling old and your heart is breaking.",
        "I don't want to talk if it makes you feel sad, and I understand you've come to shake my hand. I apologize if it makes you feel bad seeing me so tense.",
        "When I ask him if quiz bowl has helped him in other areas of his life, he seems amused by the notion that there could even be other areas of his life.",
        "I think what our insightful young friend is saying is that we welcome the inevitable seasons of nature, but we're upset by the seasons of our economy.",
        "You crushed us to build your monarchy on the backs of our blood and bone. Your mistake wasn't keeping us alive. It was thinking we'd never fight back!",
        "This legendary dragon is a powerful engine of destruction. Virtually invincible, very few have faced this awesome creature and lived to tell the tale.",
        "All falsehood is a mask; and however well made the mask may be, with a little attention we may always succeed in distinguishing it from the true face.",
        "If you had an injury and your doctor said it might help, would you be willing to let leeches feast for a few minutes, say, on your hand? On your face?",
        "It's a four ton truck, Tyrone, it's not as though it's a packet of peanuts, is it? It was behind you, whenever you reverse things come from behind you!",
        "Just because there are things I don't remember doesn't make my actions meaningless. The world doesn't just disappear when you close your eyes, does it?",
        "Who am I? I haunt your dreams like a ghost, for I know what scares you most. So you run, run! As fast as you can! There's no escape from the magic man.",
        "There is a stubbornness about me that never can bear to be frightened at the will of others. My courage always rises at every attempt to intimidate me.",
        "Yes, there were times, I'm sure you knew, when I bit off more than I could chew. But through it all, when there was doubt, I ate it up and spit it out.",
        "If you've had half as much fun watching the show as we've had doing it, well then we've had twice as much fun doing the show as you've had watching it.",
        "Concealing the origins of money obtained illegally by passing it through a complex sequence of banking transfers or commercial transactions is a crime.",
        "I was long into my second decade of living single before I came to see my friends in the city for what they were: my personal community, my urban tribe.",
        };
    private string wordsInSentences = "You were not meant to see this. This is a bug.";
    private List<string> wordsInList;
    private int nextWordIndex;
    private int textChosenIndex;
    void Awake()
    {

        if (instance != null)
            GameObject.Destroy(instance);
        else
            instance = this;
        //DontDestroyOnLoad(this); //uncomment this if you want to keep this script when another scene loads
        textChosenIndex = Random.Range(0, textsAvailable.Length);
        wordsInSentences = textsAvailable[textChosenIndex];
        if (TogglesManager.instance.moreWords == true)
        {
            wordsInList = new List<string>(wordsInSentences.Split(' '));
            wordsInList.AddRange(wordsInSentences.Split(' '));
            wordsInList.AddRange(wordsInSentences.Split(' '));
        }
        else
        {
            wordsInList = new List<string>(wordsInSentences.Split(' '));
        }

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
        if (nextWordIndex >= wordsInList.Count)
        {
            if (EnemySpawner.spawnedEnemies.Count == 0)
            {
                TogglesManager.instance.CheckMissionConditions();
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
