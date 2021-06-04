using UnityEngine;

public class Equipment : MonoBehaviour
{
    public static Equipment instance;

    public delegate void OnItemChangedE(Item oldItem, Item newItem);
    public OnItemChangedE onItemChangedECallback;

    //public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    //public OnEquipmentChanged onEquipmentChanged;

    private void Awake()
    {

        instance = this;
    }

    public Item head;
    public Item chest;
    public Item legs;
    public Item weapon;

    public bool Add(Item item)
    {
        //Debug.Log("Equipment Add");
        Item oldItem = null;
        if (item.type == "head")
        {
            //Debug.Log("it's a head item");
            if (head != null)
            {
                oldItem = head;
                Inventory.instance.Add(head);
            }
            head = item;
            Inventory.instance.Remove(item);
        }
        else if (item.type == "chest")
        {
            if (chest != null)
            {
                oldItem = chest;
                Inventory.instance.Add(chest);
            }
            chest = item;
            Inventory.instance.Remove(item);
        }
        else if (item.type == "legs")
        {
            if (legs != null)
            {
                oldItem = legs;
                Inventory.instance.Add(legs);
            }
            legs = item;
            Inventory.instance.Remove(item);
        }
        else if (item.type == "weapon")
        {
            if (weapon != null)
            {
                oldItem = weapon;
                Inventory.instance.Add(weapon);
            }
            weapon = item;
            Inventory.instance.Remove(item);
        }
        else
        {
            return false;
        }
        if (onItemChangedECallback != null)
        {
            onItemChangedECallback.Invoke(oldItem, item);
            return true;
        }
        return false;
    }

    public void Remove(Item item)
    {
        //Debug.Log("Equipment Remove");
        Item oldItem = null;
        if (item.type == "head" && Inventory.instance.Add(item))
        {
            oldItem = head;
            head = null;
        }
        else if (item.type == "chest" && Inventory.instance.Add(item))
        {
            oldItem = chest;
            chest = null;
        }
        else if (item.type == "legs" && Inventory.instance.Add(item))
        {
            oldItem = legs;
            legs = null;
        }
        else if (item.type == "weapon" && Inventory.instance.Add(item))
        {
            oldItem = weapon;
            weapon = null;
        }
        else
        {
            Debug.Log("this shouldn't happen");
            return;
        }
        if (onItemChangedECallback != null)
        {
            onItemChangedECallback.Invoke(oldItem, null);
        }
    }
}
