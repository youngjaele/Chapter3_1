using System.IO.Pipes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupEquip : MonoBehaviour
{
    public TMP_Text infoText;
    public Button confirmBtn;

    [SerializeField] private GameObject popupEquip;

    public void PopupSetting(ItemSlot slot)
    {
        popupEquip.SetActive(true);

        if (slot.inputData.isEquiped)
        {
            infoText.text = "������ �����Ͻðڽ��ϱ� ?";
            confirmBtn.onClick.RemoveAllListeners();
            confirmBtn.onClick.AddListener(() =>
            {
                slot.inputData.isEquiped = false;
                slot.ChangeEquip();
                popupEquip.SetActive(false);
            });

        }
        else
        {
            infoText.text = "���� �Ͻðڽ��ϱ� ?";
            confirmBtn.onClick.RemoveAllListeners();
            confirmBtn.onClick.AddListener(() =>
            {
                slot.inputData.isEquiped = true;
                slot.ChangeEquip();
                popupEquip.SetActive(false);
            });
        }
    }
}