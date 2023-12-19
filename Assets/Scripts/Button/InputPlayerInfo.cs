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
                slotTextUI[i].text = "빈 슬롯";
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
            print($"현재 슬롯 {number}");
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
                Debug.Log($"이름이 입력되었어 {playerName}");
                Debug.Log($"2슬롯은 {PlayerManager.instance.slotNumber}");
                PlayerManager.instance.SavePlayerData();
                GameStart(number);
            }
            else
            {
                Debug.Log("이름이 짧아"); // 오류 창 띄우기
            }
        }
    }

    public void GameStart(int number)
    {
        PlayerManager.instance.LoadPlayerData(number);
        SceneManager.LoadScene("MainScene");
        int selectedSlot = PlayerManager.instance.slotNumber;
        PlayerManager.instance.slotNumber = selectedSlot;
        Debug.Log($"게임내부 슬롯은 {PlayerManager.instance.slotNumber}");
    }
}
//void Update()
//{
//    // 엔터로 입력가능
//    if (Input.GetKeyDown(KeyCode.Return))
//    {
//        SavePlayerInfo();
//    }
//}
