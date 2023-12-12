using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerNameText;

    void Start()
    {
        CharacterStats characterStats = PlayerManager.instance.currentplayer;

        if (_playerNameText != null)
        {
            _playerNameText.text = characterStats.characterName;
        }

    }
}
