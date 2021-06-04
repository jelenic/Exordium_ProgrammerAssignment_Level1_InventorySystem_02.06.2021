using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{

    Item item;
    public Image icon;
    public Button unequipButton;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void AddItem(Item newItem)
    {
        //Debug.Log("EquipmentSlot AddItem");
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        unequipButton.interactable = true;

    }

    public void ClearSlot()
    {
        //Debug.Log("EquipmentSlot ClearSlot");
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        unequipButton.interactable = false;
    }

    public void OnUnequipButton()
    {
        //Debug.Log("EquipmentSlot UnequipBtn");
        Equipment.instance.Remove(item);
    }
}
