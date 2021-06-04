using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public int space = 40;

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback;

    private void Awake()
    {
        instance = this;
        space = 40;
        items = new List<Item>();
    }

    public List<Item> items;

    public bool Add(Item item)
    {
        if (items.Count < space)
        {
            //bool containsItem = items.Any(x => x.name == item.name);
            int index = items.FindIndex(a => a.name == item.name);
            if (item.stackable && index!=-1)
            {
                if (items[index].quantity < items[index].maxQuantity || items[index].maxQuantity==0)
                {
                    items[index].quantity += 1;
                    if (onItemChangedCallback != null)
                    {
                        onItemChangedCallback.Invoke();
                    }
                    return true;
                }
                else
                {
                    Debug.Log("max stack reached, item ignored");
                    return false;
                }
            }
            items.Add(item);
            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
            return true;
        }
        else
        {
            Debug.Log("to many items in inventory");
            return false;
        }
    }

    public void Remove(Item item)
    {
        int index = items.FindIndex(a => a.name == item.name);
        if (item.stackable && index != -1)
        {
            items[index].quantity -= 1;
            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
            if (items[index].quantity >= 1)
            {
                return;
            }
        }
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
