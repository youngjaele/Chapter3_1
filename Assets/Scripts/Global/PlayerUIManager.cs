using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    public static PlayerUIManager instance;
    public UserData userData;
    [SerializeField] private GameObject playerUI;

    public static PlayerUIManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject pui = new GameObject("PlayerUIManager");
                pui.AddComponent<PlayerUIManager>();
                instance = pui.GetComponent<PlayerUIManager>();
            }
            return instance;
        }
        set
        {
            if(instance == null) 
                instance = value;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this) 
                Destroy(this);
        }

        playerUI.SetActive(false);
    }
}
