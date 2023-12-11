using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    private CharacterStats characterStats;
    int currentMoney;

    void Start()
    {
        
    }

    private void Awake()
    {
        instance = this;

        characterStats = new CharacterStats
        {
            money = 50000
        };
        currentMoney = characterStats.money;
    }

    public int GetMoney()
    {
        return currentMoney;
    }
}
