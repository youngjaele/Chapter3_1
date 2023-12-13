using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    private CharacterStats characterStats;

    public int playerCurrentMoney { get; private set; }
    public int playerCurrentBankMoney { get; private set; }

    private void Awake()
    {
        instance = this;

        characterStats = PlayerManager.instance.currentplayer;

        playerCurrentMoney = characterStats.money;
        playerCurrentBankMoney = characterStats.bankMoney;

    }

    private void Start()
    {
        playerCurrentMoney = 70000;
        playerCurrentBankMoney = 150000;
    }
}
