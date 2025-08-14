using UnityEngine;
using UnityEngine.UI;

public class DamageHealing : MonoBehaviour 
{
  
    private HealthSystem healthSys;
    public int damage = 0;
    public enum DamageType {Heal,Deal}
    public DamageType damageType;

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<HealthSystem>() != null)
        {
            healthSys = other.gameObject.GetComponent<HealthSystem>();
            switch (damageType)
            {
                case (DamageType.Heal):
                    healthSys.HealDamage(damage);
                    if (other.GetComponentInChildren<EnemyStatsBar>() != null)
                    {
                        other.GetComponentInChildren<EnemyStatsBar>().UpdateValue(other.GetComponentInChildren<Image>());
                        
                    }
                        break;
                case (DamageType.Deal):
                    healthSys.DealDamage(damage);
                    if (other.GetComponentInChildren<EnemyStatsBar>() != null)
                    {
                        other.GetComponentInChildren<EnemyStatsBar>().UpdateValue(other.GetComponentInChildren<Image>());
                    }
                        break;
            }
        }
    }
}
