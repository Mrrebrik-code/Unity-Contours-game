using UnityEngine;
using UnityEngine.EventSystems;

public class Cards : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public int id;
    [SerializeField] private RectTransform groupe = new RectTransform();
    [SerializeField] private RectTransform groupe2 = new RectTransform();
    [SerializeField] private CanvasGroup canvaseGroupe = new CanvasGroup();

    [SerializeField] private Canvas canvas = new Canvas();
    [HideInInspector] public RectTransform rectCard = new RectTransform();
    [HideInInspector] public Vector3 startPosition = new Vector3();

    private void Awake()
    {
        rectCard = GetComponent<RectTransform>();
        canvaseGroupe = GetComponent<CanvasGroup>();
        startPosition = rectCard.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvaseGroupe.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvaseGroupe.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectCard.anchoredPosition += eventData.delta / canvas.scaleFactor / groupe.localScale / groupe2.localScale;
    }
}
