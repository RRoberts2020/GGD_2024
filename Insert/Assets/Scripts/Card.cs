using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Parent script of DAD and CDAD
    [HideInInspector] public int point;
    [HideInInspector] public string word;

    public virtual int GetCardValue()
    {
        return point;
    }
}
