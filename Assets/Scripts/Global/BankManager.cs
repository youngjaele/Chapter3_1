using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    public static BankManager instance;
    public UserData userData;

    [SerializeField] private GameObject bankUI;
    // BankUI Menu PlayerName DepositedMoney 
    [SerializeField] private TextMeshProUGUI playerName;

    private void Awake()
    {
        instance = this;
        bankUI.SetActive(false);

        CharacterStats characterStats = PlayerManager.instance.currentplayer;

        // Get Player Name
        string savePlayerName = characterStats.characterName;

        if (!string.IsNullOrEmpty(savePlayerName))
        {
            playerName.text = savePlayerName;
        }
        else
        {
            Debug.Log("플레이어 이름이 없어!");
        }
    }

    public void ShowBankUI()
    {
        bankUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ExitBank()
    {
        bankUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
