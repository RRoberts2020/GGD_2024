using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class JokeScore : MonoBehaviour
{
    //Stage 1 stuff?


    //Stage 2 stuff
    private int bonusScore;

    private int noLike;

    private int ableToVote;
    
    private float timeToReturn = 60f;

    public TextMeshProUGUI countdownText;

    public TextMeshProUGUI yesText;

    public TextMeshProUGUI noText;

    //Stage 3 stuff

    public GameManager Scene1Func;

    public GameManager Scene2Func;

    public GameManager Scene3Func;

    public GameManager Scene2;

    public GameManager Scene3;

    public TextMeshProUGUI playerResultText;

    public TextMeshProUGUI AiResultText;

    public TextMeshProUGUI EndResultText;

    private int EndResultVaule;

    public AudioSource Laugh;

    public AudioSource Boo;

    private CardArrayHandler cardarrayHandler;



    // Start is called before the first frame update
    void Start()
    {
        bonusScore = 0;
        noLike = 0;
        ableToVote = 5;

        cardarrayHandler = GameObject.FindGameObjectWithTag("CardArray").GetComponent<CardArrayHandler>();
    }

    private void Update()
    {
        if (Scene2.isStage2 == true)
        {
            if (timeToReturn > 0)
            {
                timeToReturn -= Time.deltaTime;
                DisplayTime(timeToReturn);
            }

            if (timeToReturn <= 0)
            {
                countdownText.text = string.Format("Times up, last vote available");
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        // Convert the time to seconds and milliseconds
        int seconds = Mathf.FloorToInt(timeToDisplay);
        int milliseconds = Mathf.FloorToInt((timeToDisplay - seconds) * 100);

        // Update the UI text element with the formatted time
        countdownText.text = string.Format(" Vote now! - {0:00}:{1:00}", seconds, milliseconds);
    }

    public void YesJoke()
    {
        if (ableToVote >0) 
        {
            bonusScore++;
            ableToVote--;

            yesText.text = "Yes: " + bonusScore.ToString();

            if (timeToReturn <= 0 || ableToVote <= 0)
            {
                ableToVote = -1;

                EndOfRound();
            }
        }
    }

    public void NoJoke()
    {
        if (ableToVote >0)
        {
            noLike++;
            ableToVote--;

            noText.text = "No: " + noLike.ToString();

            if (timeToReturn <= 0 || ableToVote <= 0)
            {
                ableToVote = -1;

                EndOfRound();
            }
        }
    }

    private void EndOfRound()
    {
        Scene2.isStage2 = false;
        Scene2.Stage2.SetActive(false);
        Scene3.Stage3.SetActive(true);

        playerResultText.text = "Number of yes votes: " + bonusScore.ToString() + "\n" + "Number of no votes: " + noLike.ToString(); ;
       
        AiResultText.text = "Audience rating: " + cardarrayHandler.AIscore;

        EndResultVaule = (bonusScore + cardarrayHandler.AIscore);

        EndResultText.text = "Total rating: " + EndResultVaule.ToString();

        // Play sfx based on joke value
        if (EndResultVaule > 25)
        {
            Laugh.Play();
            cardarrayHandler.AudienceJump();
        }
        else
        {
            Boo.Play();
        }
    }
    public void Reset()
    {
        Scene1Func.Stage1.SetActive(true);
        Scene2Func.Stage2.SetActive(false);
        Scene3Func.Stage3.SetActive(false);

        Scene2.isStage2 = false;

        // Reset vaules
        bonusScore = 0;
        noLike = 0;
        ableToVote = 5;
        timeToReturn = 15f;
        EndResultVaule = 0;

        yesText.text = "Yes: " + bonusScore.ToString();
        noText.text = "No: " + noLike.ToString();

        // AI score???
        cardarrayHandler.ResetValues();
    }

}
