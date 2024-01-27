using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler
{
    private RectTransform m_RectTransform;
    private Canvas m_Canvas;

    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_Canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        m_RectTransform.anchoredPosition += eventData.delta / m_Canvas.scaleFactor;
    }
}
