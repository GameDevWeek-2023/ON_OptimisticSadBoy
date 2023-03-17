using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemInteractable : Interactable
{
    [Header("Item")]
    public ItemSO item;

    public void Interact()
    {
        Debug.Log("addItem");
        InventoryManager.Instance.AddItem(item);
    }
}
