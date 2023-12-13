using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    public static BankManager instance;
    public static int currentMoney;
    public static int currentBankMoney;

    // BankUI Menu Button
    [SerializeField] private GameObject bankUI;
    [SerializeField] private GameObject SelectMenu;
    [SerializeField] private GameObject moneyDeposit;
    [SerializeField] private GameObject moneyWithdraw;

    // BankUI Menu PlayerName DepositedMoney 
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI currentBankMoneyText;
    [SerializeField] private TextMeshProUGUI currentMoneyText;

    [SerializeField] private TMP_InputField inputDepositMoney;
    [SerializeField] private TMP_InputField inputWithdrawMoney;

    TMP_InputField inputField;

    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        if (inputField != null)
        {
            inputField.onValueChanged.AddListener(OnInputValue);
        }
    }

    private void OnInputValue(string newValue)
    {
        string filter = NumberFilter(newValue);

        inputField.text = filter;
    }

    string NumberFilter(string input)
    {
        string result = "";

        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                result += c;
            }
        }
        return result;
    }

    private void Awake()
    {
        instance = this;

        UpdateCurrentMoney();

        CharacterStats characterStats = PlayerManager.instance.currentplayer;
        currentMoney = InventoryManager.instance.playerCurrentMoney;
        currentBankMoney = InventoryManager.instance.playerCurrentBankMoney;

        // Get Player Name
        string savePlayerName = characterStats.characterName;

        if (!string.IsNullOrEmpty(savePlayerName))
        {
            playerName.text = savePlayerName;
        }
        else
        {
            Debug.Log("ÇÃ·¹ÀÌ¾î ÀÌ¸§ÀÌ ¾ø¾î!");
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
        currentBankMoneyText.text = string.Format("{0:N0}", currentBankMoney);
    }

    public void ShowDepositMenu() // ÀÔ±Ý ¸Þ´º
    {
        SelectMenu.SetActive(false);
        moneyDeposit.SetActive(true);
        Debug.Log($"ÇöÀç µ·{currentMoney}, ÀºÇàµ·{currentBankMoney}");
    }

    public void ShowWithdrawMenu() // Ãâ±Ý ¸Þ´º
    {
        SelectMenu.SetActive(false);
        moneyWithdraw.SetActive(true);
        Debug.Log($"ÇöÀç µ·{currentMoney}, ÀºÇàµ·{currentBankMoney}");
    }

    public void BackMenu() // µÚ·Î °¡±â
    {
        SelectMenu.SetActive(true);
        moneyDeposit.SetActive(false);
        moneyWithdraw.SetActive(false);
        Debug.Log($"ÇöÀç µ·{currentMoney}, ÀºÇàµ·{currentBankMoney}");
    }

    public void DepositButton(int moneydeposit)
    {
        int inputMoney = 0;
        if (currentMoney >= moneydeposit && moneydeposit > 0)
        {
            currentMoney -= moneydeposit;
            currentBankMoney += moneydeposit;
            Debug.Log($"ÇöÀç µ·{currentMoney}, ÀºÇàµ·{currentBankMoney}");
            UpdateCurrentMoney();
        }
        else if (int.TryParse(inputDepositMoney.text, out inputMoney) && currentMoney > inputMoney)
        {
            currentMoney -= inputMoney;
            currentBankMoney += inputMoney;
            UpdateCurrentMoney();
        }
        else
        {
            Debug.Log($"ÇöÀç µ·{currentMoney}, ÀºÇàµ·{currentBankMoney}");
            Debug.Log("µ· ¾ø¾î");
        }
    }

    public void WithdrawButton(int moneywithdraw)
    {
        int inputMoney = 0;
        if (currentBankMoney >= moneywithdraw && moneywithdraw > 0 )
        {
            currentBankMoney -= moneywithdraw;
            currentMoney += moneywithdraw;
            Debug.Log($"ÇöÀç µ·{currentMoney}, ÀºÇàµ·{currentBankMoney}");
            UpdateCurrentMoney();
        }
        else if (int.TryParse(inputWithdrawMoney.text, out inputMoney) && currentBankMoney > inputMoney)
        {
            currentMoney += inputMoney;
            currentBankMoney -= inputMoney;
            UpdateCurrentMoney();
        }
        else
        {
            Debug.Log($"ÇöÀç µ·{currentMoney}, ÀºÇàµ·{currentBankMoney}");
            Debug.Log("µ· ¾ø¾î");
        }
    }
}
