using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmButton : MonoBehaviour
{
    void Start()
    {
        CardArrayHandler cardArrayHandler = GameObject.FindGameObjectWithTag("CardArray").GetComponent<CardArrayHandler>();
        GetComponent<Button>().onClick.AddListener(cardArrayHandler.CheckCards);
    }
}
