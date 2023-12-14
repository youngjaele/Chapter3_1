using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UserData_", menuName = "Data/UserData", order = 0)]
public class UserData : ScriptableObject
{
    public string userId;
    public string userName = "8Á¶¿¡¿ä";
    public int level;
    public int exp;
    public string description;
    public int cash;
    public int balance;

    public int atk;
    public int def;
    public int hp;
    public int cri;
}
