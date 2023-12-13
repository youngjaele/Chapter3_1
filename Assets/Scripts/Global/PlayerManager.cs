using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public CharacterStats currentplayer = new CharacterStats();

    public string filePath;
    public int slotNumber;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(instance.gameObject);
        }

        filePath = Application.persistentDataPath + "/save/";
        print(filePath);

    }

    public void SavePlayerData()
    {
        string jsonData = JsonUtility.ToJson(currentplayer);
        File.WriteAllText(filePath + slotNumber.ToString(), jsonData);
        Debug.Log($"Save ½½·Ô ³Ñ¹ö´Â {slotNumber}");
    }

    public void LoadPlayerData()
    {
        string jsonData = File.ReadAllText(filePath + slotNumber.ToString());
        currentplayer = JsonUtility.FromJson<CharacterStats>(jsonData);
        Debug.Log($"Load ½½·Ô ³Ñ¹ö´Â {slotNumber}");
    }

    public void Clear()
    {
        currentplayer = new CharacterStats();
    }
}

