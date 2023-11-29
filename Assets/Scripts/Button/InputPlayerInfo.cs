using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InputPlayerInfo : MonoBehaviour
{
    [SerializeField] private Button _loginButton;
    [SerializeField] private TMP_InputField _inputPlayerName;

    public void SavePlayerInfo()
    {
        if (_inputPlayerName != null)
        {
            string playerName = _inputPlayerName.text;

            if (0 < playerName.Length && playerName.Length <= 6)
            {

                PlayerPrefs.SetString("PlayerName", playerName);

                SceneManager.LoadScene("MainScene");
            }
            else
            {
                Debug.Log("이름이 짧아"); // 오류 창 띄우기
            }
            return;
        }

    }
    void Update()
    {
        // 엔터로 입력가능
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SavePlayerInfo();
        }
    }
}
