using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomDragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform m_RectTransform;
    private Canvas m_Canvas;
    [SerializeField] private GameObject m_SpawnLocation;
    private bool duplicate;
    private CanvasGroup m_Group;

    // Data
    private int point;

    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_Canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        duplicate = true;
        m_Group = GetComponent<CanvasGroup>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        m_RectTransform.anchoredPosition += eventData.delta / m_Canvas.scaleFactor;
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
        m_Group.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_Group.blocksRaycasts = true;
    }
}
