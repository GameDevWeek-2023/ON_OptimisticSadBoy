using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemInteractable : Interactable
{
    [Header("Item")]
    public ItemSO item;

    public AudioClip grabClip;

    public void Interact()
    {
        Debug.Log("addItem");
        InventoryManager.Instance.AddItem(item);
        GameObject.Find("SFX").GetComponent<AudioSource>().PlayOneShot(grabClip);
        Destroy(gameObject);
    }
}
