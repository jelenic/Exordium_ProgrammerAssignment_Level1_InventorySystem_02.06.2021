﻿using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image icon;
    public Button removeButton;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        //Debug.Log(player);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Instantiate(item.prefab, player.transform.position, Quaternion.identity);
        Inventory.instance.Remove(item);
    }
}