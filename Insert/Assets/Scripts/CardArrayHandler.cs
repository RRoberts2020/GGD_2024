using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CardArrayHandler : MonoBehaviour
{
    // Word data
    [SerializeField] private TextAsset wordDataSpreadsheet;
    private string[] wordData;
    private string[] words;
    private string[] wordValue;
    private string[] wordIsNoun;
    private int COLUMNS = 3;

    // Can be used in generation of random words as an upper limit on the ID generated (inclusive)
    [HideInInspector] public int rowLength;

    private void Awake()
    {
        // Load item list
        wordData = wordDataSpreadsheet.text.Split(new string[] { ",", "\n" }, System.StringSplitOptions.None);

        rowLength = (wordData.Length - 1) / COLUMNS;

        // Set all data arrays lengths
        words = new string[rowLength];
        wordValue = new string[rowLength];
        wordIsNoun = new string[rowLength];

        // Set the data arrays values
        int idCounter = 0;
        for (int i = 0; i / COLUMNS < rowLength; i += COLUMNS)
        {
            words[idCounter] = wordData[i];
            wordValue[idCounter] = wordData[i + 1];
            wordIsNoun[idCounter] = wordData[i + 2];
            idCounter++;
        }

        // Convert rowLength to start at 0
        rowLength -= 1;

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

    public string[] GetWordDataByID(int ID)
    {
        /*
         * Input an int within the index of the array to get:
         * string word
         * int value
         * bool isNoun
         */

        if (ID > rowLength)
        {
            print("Given ID exceedes rowLength");
            return null;
        }

        string[] itemData = new string[COLUMNS];
        itemData[0] = words[ID];
        itemData[1] = wordValue[ID];
        itemData[2] = wordIsNoun[ID];

        return itemData;
    }
}
