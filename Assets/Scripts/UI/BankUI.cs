using TMPro;
using UnityEngine;

public class BankUI : MonoBehaviour
{ 
    [SerializeField] TMP_Text cashTxt;
    [SerializeField] TMP_Text balanceTxt;

    [SerializeField] TMP_InputField inputValue;
    [SerializeField] TMP_InputField outputValue;

    [SerializeField] private GameObject bankUI;
    [SerializeField] GameObject popupError;
    [SerializeField] private TextMeshProUGUI playerName;

    private void Awake()
    {
        //CharacterStats characterStats = PlayerManager.instance.currentplayer;

        //// Get Player Name
        //string savePlayerName = characterStats.characterName;

        //if (!string.IsNullOrEmpty(savePlayerName))
        //{
        //    playerName.text = savePlayerName;
        //}
        //else
        //{
        //    Debug.Log("플레이어 이름이 없어!");
        //}
    }
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
        cashTxt.text = FormatNumber(PlayerUIManager.instance.userData.cash);
        balanceTxt.text = FormatNumber(PlayerUIManager.instance.userData.balance);
    }

    public void Deposit(int money)
    {
        if(money > PlayerUIManager.instance.userData.balance)
        {
            popupError.SetActive(true);
            return;
        }

        PlayerUIManager.instance.userData.cash += money;
        PlayerUIManager.instance.userData.balance -= money;

        Refresh();
    }

    public void Withdraw(int money)
    {
        if (money > PlayerUIManager.instance.userData.cash)
        {
            popupError.SetActive(true);
            return;
        }

        PlayerUIManager.instance.userData.balance += money;
        PlayerUIManager.instance.userData.cash -= money;

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

    public void ExitBank()
    {
        bankUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
