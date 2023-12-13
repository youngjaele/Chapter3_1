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
                slotTextUI[i].text = "빈 슬롯";
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
            print($"현재 슬롯 {number}");
        }
    }

    public void InputPlayerName()
    {
        playerSelectUI.gameObject.SetActive(false);
        inputPlayerNameUI.gameObject.SetActive(true);

        int currentSlot = PlayerManager.instance.slotNumber;

        Debug.Log($"1.5슬롯은 {currentSlot}");

        if (inputPlayerName != null)
        {
            string playerName = inputPlayerName.text;

            if (0 < playerName.Length && playerName.Length <= 6)
            {
                PlayerManager.instance.currentplayer.characterName = playerName;
                Debug.Log($"이름이 입력되었어 {playerName}");
                PlayerManager.instance.SavePlayerData();
                Debug.Log($"2슬롯은 {PlayerManager.instance.slotNumber}");
                GameStart();
            }
            else
            {
                Debug.Log("이름이 짧아"); // 오류 창 띄우기
            }
        }
    }

    public void GameStart()
    {
        int selectedSlot = PlayerManager.instance.slotNumber;
        Debug.Log($"게임내부 슬롯은 {PlayerManager.instance.slotNumber}");
       
        PlayerManager.instance.LoadPlayerData();
        PlayerManager.instance.slotNumber = selectedSlot;
        SceneManager.LoadScene("MainScene");
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
