using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelsGameSettings[] LevelsSettings;
    [SerializeField] private GameObject[] currentImageContours;
    [SerializeField] private GameObject[] currentImageCards;

    private LevelsGameSettings _level;
    private int currentLevel;
    private int nextLevl;
    private int currentSuccessfullyCell;

    public int amountSuccessfullyCell;
    public GameObject[] cards;
    public GameObject[] _contours;
    public GameObject[] GameObjectLevl;

    private void Awake()
    {
        cards = new GameObject[amountSuccessfullyCell];
        _level = LevelsSettings[0];
        LoadLevel();
    }
    public void CheckingStatusGame()
    {
        if(currentSuccessfullyCell == amountSuccessfullyCell)
        {
            WinGame();
        }
    }
    private void LoadLevel()
    {
        Debug.Log("Load Levl");
        amountSuccessfullyCell = _level.amountSuccessfullyCell;
        currentLevel = _level.level;
        nextLevl = currentLevel + 1;
        for (int i = 0; i < amountSuccessfullyCell; i++)
        {
            _contours[i] = _level.contours[i];
        }
        GameObjectLevl[_level.level - 1].SetActive(true);
        currentImageContours[nextLevl - 2].SetActive(true);
        currentImageCards[nextLevl - 2].SetActive(true);
    }
    private void NextLevel()
    {
        Debug.Log("NextLevel");
        Debug.Log("ПЕРЕХОД НА УРОВЕНЬ " + nextLevl);
        _level = LevelsSettings[nextLevl-1];
        currentImageContours[currentLevel-1].SetActive(false);
        currentImageCards[currentLevel-1].SetActive(false);
        GameObjectLevl[_level.level - 1].SetActive(false);
        LoadLevel();
    }
    public void AddSuccessfullyCell()
    {
        currentSuccessfullyCell++;
        CheckingStatusGame();
    }
    private void WinGame()
    {
        Debug.Log("Win Levl");
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].GetComponent<RectTransform>().anchoredPosition = cards[i].GetComponent<Cards>().startPosition;
        }
        currentSuccessfullyCell = 0;
        NextLevel();
    }
}
