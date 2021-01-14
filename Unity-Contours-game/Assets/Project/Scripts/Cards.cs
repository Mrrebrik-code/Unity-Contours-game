using UnityEngine;
using UnityEngine.EventSystems;

public class Cards : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public int id;
    [SerializeField] private RectTransform groupe;

    [SerializeField] private Canvas canvas;
    [HideInInspector] public RectTransform rectCard = new RectTransform();
    [HideInInspector] public Vector3 startPosition;

    private void Awake()
    {
        rectCard = GetComponent<RectTransform>();
        startPosition = rectCard.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        rectCard.anchoredPosition += eventData.delta / canvas.scaleFactor / groupe.localScale;
    }
}
