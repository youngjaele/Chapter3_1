using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    public ItemSlot[] itemslots;

    public void SetInventory()
    {
        for(int i = 0; i < DataManager.instance.gamedata.myItems.Length; i++)
        {
            itemslots[i].Init(DataManager.instance.gamedata.myItems[i]);
        }
    }
}
