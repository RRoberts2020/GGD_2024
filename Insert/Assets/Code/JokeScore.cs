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
    public int bonusScore;

    private int noLike;

    private int ableToVote;

    private float timeToReturn = 15f;

    public TextMeshProUGUI countdownText;

    public TextMeshProUGUI yesText;

    public TextMeshProUGUI noText;

    //Stage 3 stuff

    public GameManager Scene2;

    public GameManager Scene3;

    public TextMeshProUGUI playerResultText;

    public TextMeshProUGUI AiResultText;

    public TextMeshProUGUI EndResultText;

    public int EndResultVaule;

    public AudioSource Laugh;

    public AudioSource Boo;

    // Start is called before the first frame update
    void Start()
    {
        bonusScore = 0;
        noLike = 0;
        ableToVote = 5;
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

            if (timeToReturn <= 0 || ableToVote <= 0)
            {
                countdownText.text = string.Format("Times up, no more votes");
                ableToVote = -1;

                StartCoroutine(EndOfRound());
            }
        }

        if (Scene3.isStage3 == true)
        {
            if (EndResultVaule > 5)
            {
                Laugh.Play();
            }

            if (EndResultVaule < 5)
            {
                Boo.Play();
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
        }
    }

    public void NoJoke()
    {
        if (ableToVote >0)
        {
            noLike++;
            ableToVote--;

            noText.text = "No: " + noLike.ToString();
        }
    }

    IEnumerator EndOfRound()
    {
        yield return new WaitForSeconds(3);

        Scene2.Stage2.SetActive(false);
        Scene3.Stage3.SetActive(true);

        Scene3.isStage3 = true;

        playerResultText.text = "Number of yes votes: " + bonusScore.ToString() + "Number of no votes: " + noLike.ToString(); ;
       
        //AiResultText.text = "Audience rating: " + noLike.ToString();

        EndResultVaule = (bonusScore /*+ Audiance score */ );

        EndResultText.text = "Total rating: " + EndResultVaule.ToString();

        StopCoroutine(EndOfRound());
    }


}
