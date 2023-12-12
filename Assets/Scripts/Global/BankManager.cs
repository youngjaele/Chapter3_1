using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    public static BankManager instance;
    private CharacterStats characterStats;

    // BankUI Menu Button
    [SerializeField] private GameObject bankUI;
    [SerializeField] private GameObject SelectMenu;
    [SerializeField] private GameObject depositMoney;
    [SerializeField] private GameObject withdrawMoney;

    // BankUI Menu PlayerName DepositedMoney 
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI depositedMoneyText;
    [SerializeField] private TextMeshProUGUI currentMoneyText;

    private int currentMoney;
    private int depositedMoney;

    public event Action<int> OnWorkBank;

    private void Start()
    {
        OnWorkBank += DepositButton;
    }

    private void Awake()
    {
        instance = this;
        currentMoney = InventoryManager.instance.currentMoney;
        depositedMoney = 100000;

        // Get Player Name
        string savePlayerName = PlayerPrefs.GetString("PlayerName", "");

        if (!string.IsNullOrEmpty(savePlayerName))
        {
            playerName.text = savePlayerName;
        }
        else
        {
            Debug.Log("플레이어 이름이 없어!");
        }

        if (InventoryManager.instance != null)
        {
            UpdateCurrentMoney();
        }
        else
        {
            Debug.Log("인벤토리 매니저가 없어");
        }   
    }

    public void ExitBank()
    {
        bankUI.SetActive(false);
        Time.timeScale = 1f;
    }

    private void UpdateCurrentMoney()
    {
        currentMoneyText.text = string.Format("{0:N0}", currentMoney);
        depositedMoneyText.text = string.Format("{0:N0}", depositedMoney);
    }

    public void ShowDepositMenu() // 입금 메뉴
    {
        SelectMenu.SetActive(false);
        depositMoney.SetActive(true);
    }

    public void ShowWithdrawMenu() // 출금 메뉴
    {
        SelectMenu.SetActive(false);
        withdrawMoney.SetActive(true);
    }

    public void BackMenu() // 뒤로 가기
    {
        SelectMenu.SetActive(true);
        depositMoney.SetActive(false);
        withdrawMoney.SetActive(false);
    }

    public void DepositButton(int money)
    {
        OnWorkBank?.Invoke(money);
        currentMoney -= money;
        depositedMoney += money;
        Debug.Log("DepositButton Called with money: " + money);
    }

    public void WithdrawButton(int money)
    {
        OnWorkBank?.Invoke(-money);
        currentMoney += money;
        depositedMoney -= money;
    }
}
