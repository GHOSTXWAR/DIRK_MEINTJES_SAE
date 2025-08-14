using UnityEngine;

public class HealthSystem : MonoBehaviour 
{
    public int maxHealth = 100;
    public int HP = 100;

    private void OnEnable()
    {
        if (HP > maxHealth) { HP = maxHealth; }
    }
    public void DealDamage(float damage)
    {
        if (HP > 0)
        {
            HP -= (int)damage;      
        }
        if (HP <= 0)
        {
            HP = 0;
        }
    }
    public void HealDamage(float damage)
    {
        if (HP < maxHealth)
        {
            HP += (int)damage;
        }
        if (HP >= maxHealth)
        {
            HP = maxHealth;
        }
    }

}
