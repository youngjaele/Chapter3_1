using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCharacterSelectButton : MonoBehaviour
{
    [SerializeField] private Button selectBoxButton;
    [SerializeField] protected GameObject imageSelectText;
    [SerializeField] protected GameObject characterImageSelectBox;

    public void ShowSelectBox()
    {
        characterImageSelectBox.SetActive(true);
    }
}
