using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using System;

public class InventoryManager : Singleton<InventoryManager>
{

    public List<ItemSO> inventory;

    [SerializeField]
    private Image _inventoryLeftUI;
    [SerializeField]
    private Image _inventoryRightUI;
    [SerializeField]
    private RectTransform _inventoryUIWrapper;

    private Image leftImage;
    private Image rightImage;

    private Vector4 _alphaCharacterDisabled = new Vector4(1, 1, 1, 0);
    private Vector4 _alphaCharacterActive = new Vector4(1, 1, 1, 1);


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        leftImage = _inventoryLeftUI.GetComponent<Image>();
        rightImage = _inventoryRightUI.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inventory.Count > 0)
        {
            leftImage.enabled = true;
            leftImage.sprite = inventory[0].sprite;
            if (inventory.Count > 1)
            {
                rightImage.enabled = true;
                rightImage.sprite = inventory[1].sprite;
            } else
            {
                rightImage.enabled = false;
            }
        } else
        {
            leftImage.enabled = false;
        }
    }

    public void AddItem(ItemSO item)
    {
        inventory.Add(item);
    }

    public void RemoveItem(ItemSO item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
        }
    }

    public void ShowInventory()
    {
        _inventoryUIWrapper.gameObject.SetActive(true);
    }

    public void HideInventory()
    {
        _inventoryUIWrapper.gameObject.SetActive(false);
    }


}
