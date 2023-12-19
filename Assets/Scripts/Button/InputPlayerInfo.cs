using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using Unity.VisualScripting;

public class InputPlayerInfo : MonoBehaviour
{
    [SerializeField] private GameObject playerSelectUI;
    [SerializeField] private TextMeshProUGUI[] slotTextUI;
    [SerializeField] private GameObject inputPlayerNameUI;
    [SerializeField] private TMP_InputField inputPlayerName;

    bool[] saveFile = new bool[3];

    private void Start()
    {
        PlayerManager.instance.slotNumber = 0;

        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(PlayerManager.instance.filePath + $"{i}"))
            {
                saveFile[i] = true;
                PlayerManager.instance.slotNumber = i;
                PlayerManager.instance.LoadPlayerData(i);
                slotTextUI[i].text = PlayerManager.instance.currentplayer.characterName;
            }
            else
            {
                slotTextUI[i].text = "�� ����";
            }
        }
    }
    public void SlotData(int number)
    {
        
        PlayerManager.instance.slotNumber = number;

        if (saveFile[number])
        {
            GameStart(number);
        }
        else
        {
            InputPlayerName(number);
            print($"���� ���� {number}");
        }
    }

    public void InputPlayerName(int number)
    {
        playerSelectUI.gameObject.SetActive(false);
        inputPlayerNameUI.gameObject.SetActive(true);

        if (inputPlayerName != null)
        {
            string playerName = inputPlayerName.text;

            if (0 < playerName.Length && playerName.Length <= 6)
            {
                PlayerManager.instance.currentplayer.characterName = playerName;
                Debug.Log($"�̸��� �ԷµǾ��� {playerName}");
                Debug.Log($"2������ {PlayerManager.instance.slotNumber}");
                PlayerManager.instance.SavePlayerData();
                GameStart(number);
            }
            else
            {
                Debug.Log("�̸��� ª��"); // ���� â ����
            }
        }
    }

    public void GameStart(int number)
    {
        PlayerManager.instance.LoadPlayerData(number);
        SceneManager.LoadScene("MainScene");
        int selectedSlot = PlayerManager.instance.slotNumber;
        PlayerManager.instance.slotNumber = selectedSlot;
        Debug.Log($"���ӳ��� ������ {PlayerManager.instance.slotNumber}");
    }
}
//void Update()
//{
//    // ���ͷ� �Է°���
//    if (Input.GetKeyDown(KeyCode.Return))
//    {
//        SavePlayerInfo();
//    }
//}
