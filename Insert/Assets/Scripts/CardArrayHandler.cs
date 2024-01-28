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
    [SerializeField] private Transform selectionPanel;
    [SerializeField] private GameManager gameManager;
    [HideInInspector] public int AIscore;
    [SerializeField] private Transform audience;

    private GameObject gamePanel;
    [SerializeField] private Transform canvas;
    [SerializeField] private GameObject gamePanelPrefab;

    private void Awake()
    {
        ResetValues();

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

        string[] retrunWord = wordListNoun[ID];

        // Remove from list
        wordListNoun.Remove(wordListNoun[ID]);
        nounCount -= 1;

        return retrunWord;
    }

    public string[] GetWordDataByIDAdjective(int ID)
    {
        if (ID > adjectiveCount)
        {
            print("Error: ID exceeds adjectiveCount");
            return null;
        }

        string[] retrunWord = wordListAdjective[ID];

        // Remove from list
        wordListAdjective.Remove(wordListAdjective[ID]);
        adjectiveCount -= 1;

        return retrunWord;
    }

    public void CheckCards()
    {
        int counter = 0;

        // Its stupid but it works
        // Checks if the child's child has the "Word" tag and counts it, if it reaches 5 let the player progress
        selectionPanel = GameObject.Find("SelectionPanel").transform;
        foreach (Transform child in selectionPanel)
        {
            foreach (Transform grandchild in child)
            {
                if (grandchild.tag == "Word")
                {
                    AIscore += grandchild.GetComponent<Card>().point;
                    counter++;
                }
            }
        }

        if (counter == 5)
        {
            gameManager.Stage2UI();
        }
        else
        {
            print("Please fill all boxes");
        }
    }

    public void AudienceJump()
    {
        foreach (Transform child in audience)
        {
            child.GetComponent<Audience>().jumpForce = 5;
        }
    }

    public void ResetValues()
    {
        if (gamePanel != null)
        {
            Destroy(gamePanel);
        }

        gamePanel = Instantiate(gamePanelPrefab, canvas);

        selectionPanel = GameObject.Find("SelectionPanel").transform;

        AIscore = 0;

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

        foreach (Transform child in audience)
        {
            child.GetComponent<Audience>().jumpForce = 0.6f;
        }
    }
}
