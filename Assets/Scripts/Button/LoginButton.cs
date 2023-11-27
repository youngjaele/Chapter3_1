using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputPlayerName;

    //private void Awake()
    //{
    //    _playerName = _inputPlayerName.GetComponent<InputField>().text;    
    //}
    //private void Start()
    //{
    //    Button loginButton = GetComponent<Button>();
    //    if (loginButton != null)
    //    {
    //        loginButton.onClick.AddListener(InputNameAndLoadMainScene);
    //    }
    //    else
    //    {
    //        Debug.LogError("Button component not found on LoginButton object!");
    //    }
    //}

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
        else
        {
            Debug.LogError("_inputPlayerName is null!");
        }

    }
    void Update()
    {
        // 엔터 키를 누르면 InputNameAndLoadMainScene() 호출
        if (Input.GetKeyDown(KeyCode.Return))
        {
            InputNameAndLoadMainScene();
        }
    }
}
