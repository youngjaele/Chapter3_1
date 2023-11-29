using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterSelectMenuMsg : StartCharacterSelectButton
{

    [SerializeField] private Button playerImageButton1;
    [SerializeField] private Button playerImageButton2;
    [SerializeField] private Button NoneSelectButton;

    [SerializeField] private GameObject playerImage1;
    [SerializeField] private GameObject playerImage2;

    public void CharacterImageInput1()
    {
        characterImageSelectBox.SetActive(false);
        playerImage1.SetActive(true);
        imageSelectText.SetActive(false);

        if (playerImage2)
        {
            playerImage2.SetActive(false);
        }
    }

    public void CharacterImageInput2()
    {
        characterImageSelectBox.SetActive(false);
        playerImage2.SetActive(true);
        imageSelectText.SetActive(false);

        if (playerImage1)
        {
            playerImage1.SetActive(false);
        }
    }

    public void NoneSelectInput()
    {
        characterImageSelectBox.SetActive(false);
        imageSelectText.SetActive(true);

        if (playerImage1)
        {
            playerImage1.SetActive(false);
        }

        if (playerImage2)
        {
            playerImage2.SetActive(false);
        }
    }
}
