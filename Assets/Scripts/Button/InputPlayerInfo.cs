using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class InputPlayerInfo : MonoBehaviour
{
    [SerializeField] private GameObject playerSelectUI;
    [SerializeField] private TextMeshProUGUI[] slotTextUI;
    [SerializeField] private GameObject inputPlayerNameUI;
    [SerializeField] private TMP_InputField inputPlayerName;

    bool[] saveFile = new bool[3];

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(PlayerManager.instance.filePath + $"{i}"))
            {
                saveFile[i] = true;
                PlayerManager.instance.slotNumber = i;
                PlayerManager.instance.LoadPlayerData();
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
            PlayerManager.instance.LoadPlayerData();
            GameStart();
        }
        else
        {
            InputPlayerName();
            print($"���� ���� {number}");
        }
    }

    public void InputPlayerName()
    {
        playerSelectUI.gameObject.SetActive(false);
        inputPlayerNameUI.gameObject.SetActive(true);

        int currentSlot = PlayerManager.instance.slotNumber;

        Debug.Log($"1.5������ {currentSlot}");

        if (inputPlayerName != null)
        {
            string playerName = inputPlayerName.text;

            if (0 < playerName.Length && playerName.Length <= 6)
            {
                PlayerManager.instance.currentplayer.characterName = playerName;
                Debug.Log($"�̸��� �ԷµǾ��� {playerName}");
                PlayerManager.instance.SavePlayerData();
                Debug.Log($"2������ {PlayerManager.instance.slotNumber}");
                GameStart();
            }
            else
            {
                Debug.Log("�̸��� ª��"); // ���� â ����
            }
        }
    }

    public void GameStart()
    {
        int selectedSlot = PlayerManager.instance.slotNumber;
        Debug.Log($"���ӳ��� ������ {PlayerManager.instance.slotNumber}");
       
        PlayerManager.instance.LoadPlayerData();
        PlayerManager.instance.slotNumber = selectedSlot;
        SceneManager.LoadScene("MainScene");
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
