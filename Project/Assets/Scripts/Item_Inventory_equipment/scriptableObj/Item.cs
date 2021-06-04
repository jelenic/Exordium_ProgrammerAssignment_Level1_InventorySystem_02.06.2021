
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public string type = null;

    //public enum type { head, chest, legs, weapon}

    public GameObject prefab = null;

    public int attack = 0;
    public int defence = 0;
    public int speed = 0;
    public int dexterity = 0;


    public virtual void Use()
    {
        Debug.Log("using" + name);
        if (type == "consumable")
        {
            Debug.Log("using consumable");
            Inventory.instance.Remove(this);
        }
        if (Equipment.instance.Add(this))
        {
            return;
        }
    }

}
