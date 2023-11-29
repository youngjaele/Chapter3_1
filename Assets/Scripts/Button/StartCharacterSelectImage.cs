using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCharacterSelectImage : MonoBehaviour
{
    [SerializeField] private GameObject characterImageSelectBox;
    [SerializeField] private GameObject imageSelectText;
    [SerializeField] private Button selectBoxButton;

    [SerializeField] private Button playerImageButton1;
    [SerializeField] private Button playerImageButton2;
    [SerializeField] private GameObject playerImage1;
    [SerializeField] private GameObject playerImage2;


    private void Awake()
    {
        selectBoxButton.onClick.AddListener(ShowSelectBox);
        characterImageSelectBox.SetActive(false);
    }

    void Start()
    {
        
    }

    public void ShowSelectBox()
    {
        characterImageSelectBox.SetActive(true);
        imageSelectText.SetActive(false);
    }

    public void SelectCharacterImageInput()
    {
        if (playerImageButton1)
        {
            characterImageSelectBox.SetActive(false);
            playerImage1.SetActive(true);

            if (playerImage2)
            {
                playerImage2.SetActive(false);
            }
        }
        else if (playerImageButton2)
        {
            characterImageSelectBox.SetActive(false);
            playerImage2.SetActive(true);

            if (playerImage1)
            {
                playerImage1.SetActive(false);
            }
        }
        else
        {
            characterImageSelectBox.SetActive(false);
            Debug.Log(" πÃº±≈√ ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
