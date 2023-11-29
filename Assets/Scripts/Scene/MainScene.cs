using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerNameText;

    void Start()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "DefaultName");
        if (_playerNameText != null)
        {
            _playerNameText.text = playerName;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
