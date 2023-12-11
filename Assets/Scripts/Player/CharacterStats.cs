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
    
    [Range(0, 100)]public int maxHealth;
    [Range(1f, 20f)] public float speed;
    [Range(0, 10000000)] public int money;

    // ���� ������
    public AttackSO attackSO;
}


