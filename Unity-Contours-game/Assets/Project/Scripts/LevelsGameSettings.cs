using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsSettings", menuName = "ScriptableObjects/LevelSettings", order = 1)]
public class LevelsGameSettings : ScriptableObject
{
    public GameObject levelGroup;
    public int level;
    public int amountSuccessfullyCell;
    public GameObject[] contours;
}
