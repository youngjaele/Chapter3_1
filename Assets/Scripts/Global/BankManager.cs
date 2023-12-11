using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    public static BankManager instance;

    // BankUI Menu Button
    [SerializeField] private GameObject SelectMenu;
    [SerializeField] private GameObject depositMoney;
    [SerializeField] private GameObject withdrawMoney;

    // BankUI Menu PlayerName DepositedMoney 
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI depositedMoney;
    [SerializeField] private TextMeshProUGUI currentMoney;

    private void Awake()
    {
        instance = this;

        // Get Player Name
        string savePlayerName = PlayerPrefs.GetString("PlayerName", "");

        if (!string.IsNullOrEmpty(savePlayerName))
        {
            playerName.text = savePlayerName;
        }
        else
        {
            Debug.Log("�÷��̾� �̸��� ����!");
        }
        
        if(InventoryManager.instance != null)
        {
            UpdateCurrentMoney();
        }
        else
        {
            Debug.Log("�κ��丮 �Ŵ����� ����");
        }
        
    }

    private void Update()
    {
 
    }

    private void UpdateCurrentMoney()
    {
        int _currentMoney = InventoryManager.instance.GetMoney();

        currentMoney.text = string.Format("{0:N0}", _currentMoney);
    }

    public void ShowDepositMenu() // �Ա� �޴�
    {
        SelectMenu.SetActive(false);
        depositMoney.SetActive(true);
    }

    public void ShowWithdrawMenu() // ��� �޴�
    {
        SelectMenu.SetActive(false);
        withdrawMoney.SetActive(true);
    }

    public void BackMenu() // �ڷ� ����
    {
        SelectMenu.SetActive(true);
        depositMoney.SetActive(false);
        withdrawMoney.SetActive(false);
    }

    public void DepositButton()
    {
        // �Ա� ��ư 1, 3, 5 ,����
    }

    public void WithdrawButton()
    {
        // ��� ��ư 1, 3, 5 ,����
    }

    public void DepositMoney(int money)
    {
        // �Ա� �Լ�
    }
    public void WithdrawMoney(int money)
    {
        // ��� �Լ�
    }
}
