using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InputName : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputPlayerName;

    public void InputNameAndLoadMainScene()
    {
        if (_inputPlayerName != null)
        {
            string playerName = _inputPlayerName.text;

            if (0 < playerName.Length && playerName.Length <= 6)
            {

                PlayerPrefs.SetString("PlayerName", playerName);
                PlayerPrefs.Save();

                SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
            }
        }
    }
    void Update()
    {
        // 엔터로 입력가능
        if (Input.GetKeyDown(KeyCode.Return))
        {
            InputNameAndLoadMainScene();
        }
    }
}
