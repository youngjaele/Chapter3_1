using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField] private GameObject statusUI;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject playerInfoUI;

    [SerializeField] private TMP_Text cashTxtUI;
    [SerializeField] private TMP_Text playerName;
    [SerializeField] private TMP_Text playerLevel;

    private bool isUIActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowPlayerUI();
        }
    }

    string FormatNumber(int num)
    {
        return string.Format("{0:N0}", num);
    }

    public void Refresh()
    {
        cashTxtUI.text = FormatNumber(PlayerUIManager.instance.userData.balance);
        playerLevel.text = PlayerUIManager.instance.userData.level.ToString();
    }

    private void ShowPlayerUI()
    {
        isUIActive = !isUIActive;
        if (isUIActive)
        {
            Refresh();
            playerInfoUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            playerInfoUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
