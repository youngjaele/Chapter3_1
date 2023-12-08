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
    public StatsChangeType statChangeType;
    
    [Range(0, 100)]public int maxHealthl;
    [Range(1f, 20f)] public float speed;

    // ���� ������
    public AttackSO attackSO;
}

