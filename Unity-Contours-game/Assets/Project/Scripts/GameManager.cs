using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool buttonNext;
    public GameObject winPanel;

    [SerializeField] private LevelsGameSettings[] LevelsSettings;
    [SerializeField] private GameObject[] currentImageContours;
    [SerializeField] private GameObject[] currentImageCards;
    public ContoursLevels[] contoursLevelGame;

    private LevelsGameSettings _level;
    public int currentLevel;
    private int nextLevl;
    private int currentSuccessfullyCell;

    public int amountSuccessfullyCell;
    public GameObject[] cards;
    public GameObject[] _contours;
    public GameObject[] GameObjectLevl;

    public GameObject error;

    public AudioSource audioSourceMusic;
    public AudioSource audioSourceSound;
    public AudioClip fonMusic;
    public AudioClip faillSound;
    public AudioClip dropSound;
    public AudioClip stopGameSound;
    public AudioClip winLevelSound;

    private void Awake()
    {
        audioSourceMusic.PlayOneShot(fonMusic);
        cards = new GameObject[amountSuccessfullyCell];
        _level = LevelsSettings[DataHolder._levelStart];
        LoadLevel();
    }
    public void CheckingStatusGame()
    {
        if(currentSuccessfullyCell == amountSuccessfullyCell)
        {
            winPanel.SetActive(true);
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
        for(int i = 0; i< cards.Length; i++)
        {
            cards[i] = null;
        }
    }
    private void NextLevel()
    {
        try
        {
            Debug.Log("NextLevel");
            Debug.Log("ПЕРЕХОД НА УРОВЕНЬ " + nextLevl);
            _level = LevelsSettings[nextLevl - 1];
            currentImageContours[currentLevel - 1].SetActive(false);
            currentImageCards[currentLevel - 1].SetActive(false);
            GameObjectLevl[_level.level - 1].SetActive(false);
            LoadLevel();
        }
        catch
        {
            error.SetActive(true);
            audioSourceMusic.PlayOneShot(stopGameSound);
        }
    }
    public void AddSuccessfullyCell()
    {
        currentSuccessfullyCell++;
        CheckingStatusGame();
    }
    private void WinGame()
    {
        Debug.Log("Win Levl");
        audioSourceMusic.PlayOneShot(winLevelSound);
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].GetComponent<RectTransform>().anchoredPosition = cards[i].GetComponent<Cards>().startPosition;
        }
        currentSuccessfullyCell = 0;
        NextLevel();
    }

    public void winGameButton()
    {
        buttonNext = true;
    }

    [Serializable]
    public class ContoursLevels
    {
        public GameObject[] _contoursLevel;
    }
}
