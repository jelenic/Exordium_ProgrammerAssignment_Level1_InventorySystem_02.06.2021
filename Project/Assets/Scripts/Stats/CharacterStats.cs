using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat attack;
    public Stat defence;
    public Stat speed;
    public Stat dexterity;

    private void Awake()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            takeDamage(10);
        }
    }

    public void takeDamage(int damage)
    {
        damage -= defence.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log("current health:" + currentHealth);
    }
}
