using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public void CreditMe()
    {
        Debug.Log("Credits were given");

        Application.OpenURL("https://globalgamejam.org/games/2024/insert-joke-here-9");
    }
}
