using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{
    Equipment equipment;

    public Text defenceText;
    public Text attackText;
    public Text speedText;
    public Text dexterityText;

    private void Start()
    {
        equipment = Equipment.instance;
        equipment.onItemChangedECallback += OnItemChangedE;
    }

    //i really should pass what item is changed ina callback
    void OnItemChangedE(Item oldItem, Item newItem)
    {
        if (newItem != null)
        {
            defence.AddModifier(newItem.defence);
            attack.AddModifier(newItem.attack);
            speed.AddModifier(newItem.speed);
            dexterity.AddModifier(newItem.dexterity);
        }
        if (oldItem != null)
        {
            defence.RemoveModifier(oldItem.defence);
            attack.RemoveModifier(oldItem.attack);
            speed.RemoveModifier(oldItem.speed);
            dexterity.RemoveModifier(oldItem.dexterity);
        }
        setText();
    }

    void setText()
    {
        defenceText.text = defence.sumStat().ToString();
        attackText.text = attack.sumStat().ToString();
        speedText.text = speed.sumStat().ToString();
        dexterityText.text = dexterity.sumStat().ToString();
    }

}
