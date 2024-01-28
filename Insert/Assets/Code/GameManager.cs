using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject Stage1;

    public GameObject Stage2;

    public GameObject Stage3;

    public bool isStage2;


    // Start is called before the first frame update
    void Start()
    {
        Stage1 = GameObject.FindGameObjectWithTag("GamePanel");
        Stage1.SetActive(true);
        Stage2.SetActive(false);
        Stage3.SetActive(false);

        isStage2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Stage2UI() 
    {
        Stage1 = GameObject.FindGameObjectWithTag("GamePanel");
        Stage1.SetActive(false);
        Stage2.SetActive(true);
        Stage3.SetActive(false);

        isStage2 = true;
    }

    public void Stage3UI()
    {
        Stage1 = GameObject.FindGameObjectWithTag("GamePanel");
        Stage1.SetActive(false);
        Stage2.SetActive(false);
        Stage3.SetActive(true);

        isStage2 = false;
    }


}
