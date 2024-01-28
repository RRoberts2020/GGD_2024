using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomDragAndDrop : Card, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform m_RectTransform;
    private Canvas m_Canvas;
    [SerializeField] private GameObject m_SpawnLocation;
    private bool duplicate;
    private CanvasGroup m_Group;
    private Transform m_Parent;

    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_Canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        duplicate = true;
        m_Group = GetComponent<CanvasGroup>();
        m_Parent = transform.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        m_RectTransform.anchoredPosition += eventData.delta / m_Canvas.scaleFactor;
        GetCardValue();
    }

    public void MakeCustom()
    {
        if (duplicate)
        {
            CustomDragAndDrop newOption = Instantiate(this, m_SpawnLocation.transform);
            newOption.GetComponentInChildren<TMP_InputField>().enabled = false;
            newOption.duplicate = false;
        }
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

    public override int GetCardValue()
    {
        // Calculate card value
        string text = GetComponentInChildren<TMP_InputField>().text;
        string[] words = text.Split(new string[] { " " }, System.StringSplitOptions.None);

        // Base 3 points, minus number of words
        point = 3 - words.Length;
        word = text;

        return point;
    }
}
