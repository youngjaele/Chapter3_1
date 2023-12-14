using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData", order = 2)]
public class GameData : ScriptableObject
{
    public ItemData[] myItems;
}
