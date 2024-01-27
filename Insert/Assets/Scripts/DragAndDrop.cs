using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler
{
    [SerializeField] private bool noun;
    private RectTransform m_RectTransform;
    private Canvas m_Canvas;
    private CardArrayHandler m_CardArrayHandler;
    private TextMeshProUGUI m_TextMeshPro;

    // Data
    private string word;
    private int point;

    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_Canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        m_TextMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        m_RectTransform.anchoredPosition += eventData.delta / m_Canvas.scaleFactor;
    }

    private void Start()
    {
        m_CardArrayHandler = GameObject.FindGameObjectWithTag("CardArray").GetComponent<CardArrayHandler>();
        string[] wordData;

        // Get random data from noun/adjective list
        if (noun)
        {
            int id = Random.Range(0, m_CardArrayHandler.nounCount);
            wordData = m_CardArrayHandler.GetWordDataByIDNoun(id);
        }
        else
        {
            int id = Random.Range(0, m_CardArrayHandler.adjectiveCount);
            wordData = m_CardArrayHandler.GetWordDataByIDAdjective(id);
        }

        // Assign word data to variables
        if (wordData != null)
        {
            word = wordData[0];
            point = int.Parse(wordData[1]);
        }

        m_TextMeshPro.SetText(word);
    }
}