using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public UserData userData;
    public GameData gamedata;
    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject data = new GameObject("DataManager");
                data.AddComponent<DataManager>();
                instance = data.GetComponent<DataManager>();
                DontDestroyOnLoad(data);
            }
            return instance;
        }
        set
        {
            if (instance == null)
                instance = value;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (instance != this)
                Destroy(this);
        }
    }
}
