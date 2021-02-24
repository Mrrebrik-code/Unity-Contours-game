using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int _level;
    public void StartLevelButton()
    {
        DataHolder._levelStart = _level;
        SceneManager.LoadScene("Game");
    }
}
