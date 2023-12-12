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
    public int money = 50000;

    [Range(0, 100)] public int maxHealth = 100;
    [Range(1f, 20f)] public float speed = 10f;

    // 공격 데이터
    public AttackSO attackSO;
}


