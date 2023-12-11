using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    public static BankManager instance;
    private CharacterStats characterStats;
    [SerializeField] private GameObject SelectMenu;
    [SerializeField] private GameObject depositMoney;
    [SerializeField] private GameObject withdrawMoney;

    private void Awake()
    {
        instance = this;
    }

    public void ShowDepositMenu()
    {
        SelectMenu.SetActive(false);
        depositMoney.SetActive(true);
    }

    public void ShowWithdrawMenu()
    {
        SelectMenu.SetActive(false);
        withdrawMoney.SetActive(true);
    }

    public void BackMenu()
    {
        SelectMenu.SetActive(true);
        depositMoney.SetActive(false);
        withdrawMoney.SetActive(false);
    }
}
