using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{ 
    [SerializeField] TMP_Text cashTxt;
    [SerializeField] TMP_Text balanceTxt;

    [SerializeField] TMP_InputField inputValue;
    [SerializeField] TMP_InputField outputValue;

    [SerializeField] GameObject popupError;

    private void Start()
    {
        Refresh();
    }

    string FormatNumber(int num)
    {
        return string.Format("{0:N0}", num);
    }

    public void Refresh()
    {
        cashTxt.text = FormatNumber(BankManager.instance.userData.cash);
        balanceTxt.text = FormatNumber(BankManager.instance.userData.balance);
    }

    public void Deposit(int money)
    {
        if(money > BankManager.instance.userData.balance)
        {
            popupError.SetActive(true);
            return;
        }

        BankManager.instance.userData.cash += money;
        BankManager.instance.userData.balance -= money;

        Refresh();
    }

    public void Withdraw(int money)
    {
        if (money > BankManager.instance.userData.cash)
        {
            popupError.SetActive(true);
            return;
        }
        
        BankManager.instance.userData.balance += money;
        BankManager.instance.userData.cash -= money;

        Refresh();
    }

    public void CustomDeposit()
    {
        Deposit(int.Parse(inputValue.text));
    }

    public void CustomWithdraw()
    {
        Withdraw(int.Parse(outputValue.text));
    }
}
