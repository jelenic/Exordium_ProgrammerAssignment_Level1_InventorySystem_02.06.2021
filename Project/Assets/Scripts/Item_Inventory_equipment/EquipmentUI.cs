using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{

    Equipment equipment;

    public Transform slotHolderE;
    public GameObject equipmentUI;
    EquipmentSlot[] slots;

    public GameObject btn;

    // Start is called before the first frame update
    void Start()
    {
        equipment = Equipment.instance;
        equipment.onItemChangedECallback += UpdateUI;

        slots = slotHolderE.GetComponentsInChildren<EquipmentSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            equipmentUI.SetActive(!equipmentUI.activeSelf);
            btn.SetActive(!btn.activeSelf);
        }
    }
    void UpdateUI(Item oldItem, Item newItem)
    {
        //Debug.Log("EquipmentUI UpdateUI");
        if (equipment.head != null)
        {
            slots[0].AddItem(equipment.head);
        }
        else
        {
            slots[0].ClearSlot();
        }
        if (equipment.chest != null)
        {
            slots[1].AddItem(equipment.chest);
        }
        else
        {
            slots[1].ClearSlot();
        }
        if (equipment.legs != null)
        {
            slots[2].AddItem(equipment.legs);
        }
        else
        {
            slots[2].ClearSlot();
        }
        if (equipment.weapon != null)
        {
            slots[3].AddItem(equipment.weapon);
        }
        else
        {
            slots[3].ClearSlot();
        }
    }
}
