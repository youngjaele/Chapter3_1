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
            Debug.Log("플레이어 이름이 없어!");
        }
        
        if(InventoryManager.instance != null)
        {
            UpdateCurrentMoney();
        }
        else
        {
            Debug.Log("인벤토리 매니저가 없어");
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

    public void DepositButton()
    {
        // 입금 버튼 1, 3, 5 ,직접
    }

    public void WithdrawButton()
    {
        // 출금 버튼 1, 3, 5 ,직접
    }

    public void DepositMoney(int money)
    {
        // 입금 함수
    }
    public void WithdrawMoney(int money)
    {
        // 출금 함수
    }
}
