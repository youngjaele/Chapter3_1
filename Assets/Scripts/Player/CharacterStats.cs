using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override,
}

[Serializable]
public class CharacterStats
{
    public StatsChangeType statsChangeType;

    public string characterName;
    public int level = 1;

    [Range(0, 10000000)] public int money;
    [Range(0, 100000000)] public int bankMoney;

    [Range(0, 100)] public int maxHealth = 100;
    [Range(1f, 20f)] public float speed = 10f;

    // 공격 데이터
    public AttackSO attackSO;
}


