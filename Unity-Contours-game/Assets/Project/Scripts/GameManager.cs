using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] LevelsGameSettings[] LevelsSettings;
    public GameObject[] _contours;
    public GameObject[] GameObjectLevl;
    private LevelsGameSettings _level;
    [SerializeField]private GameObject[] currentImageContours;
    [SerializeField] private GameObject[] currentImageCards;
    private int currentLevel;
    private int nextLevl;
    private int currentSuccessfullyCell;
    public int amountSuccessfullyCell;
    public GameObject[] cards;

    private void Awake()
    {
        cards = new GameObject[amountSuccessfullyCell];
        _level = LevelsSettings[0];
        currentLevel = _level.level;
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
        for(int i = 0; i < amountSuccessfullyCell; i++)
        {
            _contours[i] = _level.contours[i];
        }
        GameObjectLevl[_level.level].SetActive(true);
        currentImageContours[nextLevl].SetActive(true);
        currentImageCards[nextLevl].SetActive(true);

    }
    private void NextLevel()
    {
        Debug.Log("NextLevel");
        Debug.Log("ПЕРЕХОД НА УРОВЕНЬ " + nextLevl);
        _level = LevelsSettings[nextLevl];
        currentImageContours[currentLevel].SetActive(false);
        currentImageCards[currentLevel].SetActive(false);
        GameObjectLevl[_level.level].SetActive(false);
        LoadLevel();
    }

    public void AddSuccessfullyCell()
    {
        currentSuccessfullyCell++;
        CheckingStatusGame();
    }

    private void WinGame()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].GetComponent<RectTransform>().anchoredPosition = cards[i].GetComponent<Cards>().startPosition;
        }
        nextLevl = currentLevel + 1;

        currentSuccessfullyCell = 0;
        Debug.Log("Win Levl");
        NextLevel();
    }
}
