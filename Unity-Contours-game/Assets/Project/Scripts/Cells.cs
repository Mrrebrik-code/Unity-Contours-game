using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cells : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameManager _gameManager;
    private Vector2 positionCell;
    private GameObject currentEventData;

    private void Awake()
    {
        positionCell = GetComponent<RectTransform>().anchoredPosition;
    }
    public void OnDrop(PointerEventData eventData)
    {
        currentEventData = eventData.pointerDrag;
        Debug.Log(checkPointerDrag);
        if (checkPointerDrag)
        {
            for(int i = 0; i < 6; i++)
            {
                if(_gameManager.contoursLevelGame[_gameManager.currentLevel-1]._contoursLevel[i].gameObject.name == currentEventData.gameObject.name)
                {
                    _gameManager.contoursLevelGame[_gameManager.currentLevel - 1]._contoursLevel[i].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
            }
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = positionCell;
            AddCards(eventData.pointerDrag.gameObject);
            _gameManager.AddSuccessfullyCell();
            _gameManager.audioSourceSound.PlayOneShot(_gameManager.dropSound);
        }
        else
        {
            eventData.pointerDrag.GetComponent<Cards>().rectCard.anchoredPosition = eventData.pointerDrag.GetComponent<Cards>().startPosition;
            _gameManager.audioSourceSound.PlayOneShot(_gameManager.faillSound);
        }

    }
    private void AddCards(GameObject card)
    {
        for(int i = 0; i < _gameManager.cards.Length; i++)
        {
            if(_gameManager.cards[i] == null)
            {
                _gameManager.cards[i] = card;
                break;
            }
        }
    }
    bool checkPointerDrag
    {
        get
        {
            for (int i = 0; i < _gameManager.amountSuccessfullyCell; i++)
            {
                if(currentEventData.gameObject.name == _gameManager._contours[i].gameObject.name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
