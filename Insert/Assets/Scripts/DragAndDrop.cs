using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : Card, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private bool noun;
    private RectTransform m_RectTransform;
    private Canvas m_Canvas;
    private CardArrayHandler m_CardArrayHandler;
    private TextMeshProUGUI m_TextMeshPro;
    private CanvasGroup m_Group;
    private Transform m_Parent;

    // Data
    private string word;

    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_Canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        m_TextMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        m_Group = GetComponent<CanvasGroup>();
        m_Parent = transform.parent;
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

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.transform.SetParent(m_Parent, false);
        m_Group.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_Group.blocksRaycasts = true;
    }
}
