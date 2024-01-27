using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CardArrayHandler : MonoBehaviour
{
    // Word data
    [SerializeField] private TextAsset wordDataSpreadsheet;
    private string[] wordData;
    private List<string[]> wordListNoun;
    private List<string[]> wordListAdjective;
    private int COLUMNS = 3;
    // Can be used in generation of random words as an upper limit on the ID generated (inclusive)
    [HideInInspector] public int nounCount;
    [HideInInspector] public int adjectiveCount;

    private void Awake()
    {
        // Load item list
        wordData = wordDataSpreadsheet.text.Split(new string[] { ",", "\n" }, System.StringSplitOptions.None);
        wordListNoun = new List<string[]>();
        wordListAdjective = new List<string[]>();

        // Set the data arrays values
        for (int i = 0; i / COLUMNS < ((wordData.Length - 1) / COLUMNS); i += COLUMNS)
        {
            string[] data = new string[3];
            data[0] = wordData[i];
            data[1] = wordData[i + 1];
            data[2] = wordData[i + 2];

            // Check if noun
            if (bool.Parse(wordData[i + 2]))
            {
                // Add data to noun list
                wordListNoun.Add(data);
            }
            else
            {
                // Add data to adjective list
                wordListAdjective.Add(data);
            }
        }

        nounCount = wordListNoun.Count;
        adjectiveCount = wordListAdjective.Count;

        // Convert length to start at 0
        nounCount -= 1;
        adjectiveCount -= 1;

        /*
        for (int i = 0; i < 10; i++)
        {
            // Print 10 words (for testing)
            print(GetWordDataByID(Random.Range(0, rowLength))[0]);
        }
        */

        /*
        foreach (string word in words)
        {
            print(word);
        }

        foreach (string i in wordValue)
        {
            print(i);
        }

        foreach (string wordIsNounn in wordIsNoun)
        {
            print(wordIsNounn);
        }
        */
    }

    public string[] GetWordDataByIDNoun(int ID)
    {
        /*
         * Input an int within the index of the array to get:
         * string word
         * int value
         * bool isNoun
         * 
         * If noun is true return nouns
         * If false return adjectives
         */

        if (ID > nounCount)
        {
            print("Error: ID exceeds nounCount");
            return null;
        }

        return wordListNoun[ID];
    }

    public string[] GetWordDataByIDAdjective(int ID)
    {
        if (ID > adjectiveCount)
        {
            print("Error: ID exceeds adjectiveCount");
            return null;
        }

        return wordListAdjective[ID];
    }
}
