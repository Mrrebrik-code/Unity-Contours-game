using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cells : MonoBehaviour, IDropHandler
{
    [SerializeField] private int id;
    private Vector2 positionCell;

    private void Awake()
    {
        positionCell = GetComponent<RectTransform>().anchoredPosition;
    }
    public void OnDrop(PointerEventData eventData)
    {
        Cards _card = eventData.pointerDrag.GetComponent<Cards>();
        Debug.Log("Droping");
        if(id == _card.id)
        {
            _card.rectCard.anchoredPosition = positionCell;
            _card.enabled = false;
        }
        else
        {
            Debug.Log("TEST");
        }
    }
}
